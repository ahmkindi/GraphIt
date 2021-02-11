using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly DefaultOptions AlgoDefOptions = new DefaultOptions("#ffc400", "#000000", "#ff0000", "#000000");
        public void RunAlgorithm(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges)
        {
            algorithmNodes = new List<AlgorithmNode>();
            algorithmEdges = new List<Edge>();
            foreach (Node node in nodes) algorithmNodes.Add(new AlgorithmNode(node));
            foreach (Edge edge in edges) algorithmEdges.Add(new Edge(edge));

            switch (startAlgorithm.Algorithm)
            {
                case Algorithm.Kruskal:
                    Kruskal(startAlgorithm, nodes, ref algorithmNodes, edges, ref algorithmEdges);
                    break;
                case Algorithm.BFS:
                    BFS(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.DFS:
                    DFS(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.Dijkstra:
                    Dijkstra(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.DijkstraPath:
                    DijkstraPath(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
            }
        }

        public void Kruskal(StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges)
        {
            algorithmEdges.Clear();
            IEnumerable<Edge> sortedEdges = edges.OrderBy(e => e.Weight);
            Set set = new Set(nodes);
            
            foreach (Node node in nodes)
                set.MakeSet(node.NodeId);

            foreach (Edge edge in sortedEdges)
            {
                if (set.FindSet(edge.TailNodeId) != set.FindSet(edge.HeadNodeId))
                {
                    algorithmEdges.Add(edge);
                    set.Union(edge.TailNodeId, edge.HeadNodeId);
                }
            }
            
            startAlgorithm.Done = true;
        }

        public void BFS(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            Queue<NodeEdge> ToExplore = new Queue<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            ToExplore.Enqueue(new NodeEdge(startAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Dequeue();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node);
                EditAlgorithmNodes(Exploring.Node, count.ToString(), ref algorithmNodes);
                if (count > 1)
                    EditAlgorithmEdges(Exploring.Edge, ref algorithmEdges);

                count++;

                foreach (NodeEdge neighbor in Adjacent(d, Exploring.Node, nodes, algorithmEdges))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Enqueue(neighbor);
                }
            }
            startAlgorithm.Done = true;
        }

        public void DFS(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            Stack<NodeEdge> ToExplore = new Stack<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            ToExplore.Push(new NodeEdge(startAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Pop();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node);
                EditAlgorithmNodes(Exploring.Node, count.ToString(), ref algorithmNodes);
                if (count > 1)
                    EditAlgorithmEdges(Exploring.Edge, ref algorithmEdges);

                count++;

                foreach (NodeEdge neighbor in Adjacent(d, Exploring.Node, nodes, algorithmEdges))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Push(neighbor);
                }
            }
            startAlgorithm.Done = true;
        }

        public void Dijkstra(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Node Exploring;
            foreach(Node node in nodes)
            {
                if (node == startAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in nodes)
            {
                Exploring = ShortestDistance(d, startAlgorithm.StartNode, Distances, Explored);
                Explored.Add(Exploring);
                foreach(KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(d, Exploring, kvp.Key, algorithmEdges);
                    double exploringDis = Distances[Exploring];
                    if (!Explored.Contains(kvp.Key) && connector != null
                        && exploringDis != double.MaxValue && exploringDis + connector.Weight < kvp.Value)
                    {
                        Distances[kvp.Key] = exploringDis + connector.Weight;
                    }
                }
            }

            foreach(KeyValuePair<Node, double> kvp in Distances)
            {
                EditAlgorithmNodes(kvp.Key, $"Distance: {kvp.Value}", ref algorithmNodes);
            }

            startAlgorithm.Done = true;
        }

        public void DijkstraPath(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Dictionary<Node, Edge> Path = new Dictionary<Node, Edge>();
            Node Exploring;
            foreach (Node node in nodes)
            {
                if (node == startAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in nodes)
            {
                Exploring = ShortestDistance(d, startAlgorithm.StartNode, Distances, Explored);
                Explored.Add(Exploring);
                foreach (KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(d, Exploring, kvp.Key, algorithmEdges);
                    double exploringDis = Distances[Exploring];
                    if (!Explored.Contains(kvp.Key) && connector != null
                        && exploringDis != double.MaxValue && exploringDis + connector.Weight < kvp.Value)
                    {
                        Distances[kvp.Key] = exploringDis + connector.Weight;
                        Path[kvp.Key] = connector;
                    }
                }
            }

            if (!Path.ContainsKey(startAlgorithm.EndNode))
                startAlgorithm.Output = "No Path Exists";
            else
            {
                Node nodeInPath = startAlgorithm.EndNode;
                while (nodeInPath != startAlgorithm.StartNode)
                {
                    Edge edgeInPath = Path[nodeInPath];
                    EditAlgorithmNodes(nodeInPath, "", ref algorithmNodes);
                    EditAlgorithmEdges(edgeInPath, ref algorithmEdges);
                    Node prev = Path[nodeInPath].TailNode(nodes);
                    if (prev == nodeInPath && !d.Directed) prev = Path[nodeInPath].HeadNode(nodes);
                    nodeInPath = prev;
                }
                EditAlgorithmNodes(nodeInPath, "", ref algorithmNodes);
            }

            startAlgorithm.Done = true;
        }

        public void EditAlgorithmNodes(Node node, string header, ref IList<AlgorithmNode> algorithmNodes)
        {

            AlgorithmNode nodeEditing = algorithmNodes.First(n => n.Node.NodeId == node.NodeId);
            nodeEditing.Header = header;
            nodeEditing.Node.NodeColor = AlgoDefOptions.NodeColor;
            nodeEditing.Node.LabelColor = AlgoDefOptions.NodeLabelColor;
        }

        public void EditAlgorithmEdges(Edge edge, ref IList<Edge> algorithmEdges)
        {
            Edge edgeEditing = algorithmEdges.First(e => e.EdgeId == edge.EdgeId);
            edgeEditing.EdgeColor = AlgoDefOptions.EdgeColor;
            edgeEditing.LabelColor = AlgoDefOptions.EdgeLabelColor;
        }

        public IList<NodeEdge> Adjacent(DefaultOptions d, Node node, IList<Node> nodes, IList<Edge> edges)
        {
            var adj = new List<NodeEdge>();
            foreach(Edge edge in edges.Where(e => e.TailNodeId == node.NodeId)) 
            {
                adj.Add(new NodeEdge(nodes.First(n => n.NodeId == edge.HeadNodeId), edge));
            }
            if (!d.Directed)
            {
                foreach (Edge edge in edges.Where(e => e.HeadNodeId == node.NodeId))
                {
                    adj.Add(new NodeEdge(nodes.First(n => n.NodeId == edge.TailNodeId), edge));
                }
            }
            return adj;
        }

        public Edge ConnectingEdge(DefaultOptions d, Node tail, Node head, IList<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !d.Directed))
                {
                    return edge;
                }
            }
            return null;
        }

        public Node ShortestDistance(DefaultOptions d, Node start, Dictionary<Node, double> distances, IList<Node> explored)
        {
            Node closest = null;
            foreach(KeyValuePair<Node, double> kvp in distances)
            {
                if (!explored.Contains(kvp.Key))
                {
                    if (closest == null) closest = kvp.Key;
                    else if (kvp.Value <= distances[closest]) closest = kvp.Key;
                }
            }

            return closest;
        }

    }
}
