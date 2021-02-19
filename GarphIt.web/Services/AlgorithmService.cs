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
        private int MaxId { get; set; }
        public void RunAlgorithm(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges)
        {
            algorithmNodes.Clear();
            algorithmEdges.Clear();
            foreach (Node node in nodes) algorithmNodes.Add(new AlgorithmNode(node));
            foreach (Edge edge in edges) algorithmEdges.Add(new Edge(edge));
            MaxId = nodes.Max(n => n.NodeId);
            switch (startAlgorithm.Algorithm)
            {
                case Algorithm.Kruskal:
                    Kruskal(nodes, ref algorithmNodes, edges, ref algorithmEdges);
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
                case Algorithm.Degree:
                    Degree(d, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.DegreeCentrality:
                    DegreeCentrality(ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.MaxFlow:
                    FordFulkerson(d, startAlgorithm, ref algorithmNodes, ref algorithmEdges);
                    break;
            }
            startAlgorithm.Done = true;
        }

        public void Kruskal(IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges)
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
                    Edge connector = ConnectingEdge(d, Exploring.NodeId, kvp.Key.NodeId, algorithmEdges);
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
                    Edge connector = ConnectingEdge(d, Exploring.NodeId, kvp.Key.NodeId, algorithmEdges);
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
        }

        public void Degree(DefaultOptions d, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            Dictionary<int, int> DegreeCount = new Dictionary<int, int>();
            foreach (AlgorithmNode an in algorithmNodes) DegreeCount[an.Node.NodeId] = 0;
            foreach (Edge edge in algorithmEdges)
            {
                DegreeCount[edge.TailNodeId]++;
                if (!d.Directed) DegreeCount[edge.TailNodeId]++;
            }
            foreach (AlgorithmNode an in algorithmNodes) an.Header = DegreeCount[an.Node.NodeId].ToString();
        }

        public void DegreeCentrality(ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            Dictionary<int, int> DegreeCount = new Dictionary<int, int>();
            double maxWeight = 1;
            double minWeight = 0;
            foreach (AlgorithmNode an in algorithmNodes) DegreeCount[an.Node.NodeId] = 0;
            foreach (Edge edge in algorithmEdges)
            {
                DegreeCount[edge.TailNodeId]++;
                DegreeCount[edge.HeadNodeId]++;
                maxWeight = Math.Max(maxWeight, edge.Weight);
                if (minWeight == 0) minWeight = edge.Weight;
                else minWeight = Math.Min(minWeight, edge.Weight);
            }
            foreach (Edge edge in algorithmEdges)
            {
                double normalizedWeight = (edge.Weight - minWeight) / (maxWeight - minWeight);
                edge.Width = Math.Max(1, (int)normalizedWeight * 20);
            }
            maxWeight = 0;
            minWeight = -1;
            foreach (KeyValuePair<int, int> kvp in DegreeCount) 
            {
                maxWeight = Math.Max(kvp.Value, maxWeight);
                if (minWeight == -1) minWeight = kvp.Value;
                else minWeight = Math.Min(minWeight, kvp.Value);
            }
            foreach (AlgorithmNode an in algorithmNodes)
            {
                double normalizedWeight = (DegreeCount[an.Node.NodeId] - minWeight) / (maxWeight - minWeight);
                an.Node.Radius = Math.Max(10, (int)normalizedWeight * 100);
            }
        }

        public void FordFulkerson(DefaultOptions d, StartAlgorithm startAlgorithm, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            int u, v;
            double[,] rGraph = new double[MaxId+1, MaxId+1];

            foreach (AlgorithmNode a1 in algorithmNodes)
            {
                foreach (AlgorithmNode a2 in algorithmNodes)
                {
                    Edge adj = ConnectingEdge(d, a1.Node.NodeId, a2.Node.NodeId, algorithmEdges);
                    if (adj == null)
                        rGraph[a1.Node.NodeId, a2.Node.NodeId] = 0;
                    else rGraph[a1.Node.NodeId, a2.Node.NodeId] = adj.Weight;
                }
            }

            int[] parent = new int[MaxId+1];

            double max_flow = 0;

            while (Boolbfs(rGraph, startAlgorithm.StartNode.NodeId, startAlgorithm.EndNode.NodeId, parent, algorithmNodes))
            {
                double path_flow = double.MaxValue;
                for (v = startAlgorithm.EndNode.NodeId; v != startAlgorithm.StartNode.NodeId; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                for (v = startAlgorithm.EndNode.NodeId; v != startAlgorithm.StartNode.NodeId; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                max_flow += path_flow;
            }
            if (d.Directed)
            {
                foreach (Edge edge in algorithmEdges)
                {
                    double flow = rGraph[edge.HeadNodeId, edge.TailNodeId];
                    if (flow > 0)
                    {
                        edge.Label = $"{flow}/{edge.Weight}";
                        edge.EdgeColor = AlgoDefOptions.EdgeColor;
                    }
                }
            }
            else
            {
                foreach (Edge edge in algorithmEdges)
                {
                    double flow = rGraph[edge.HeadNodeId, edge.TailNodeId];
                    double flow2 = rGraph[edge.TailNodeId, edge.HeadNodeId];
                    if (Math.Abs(flow - flow2) > 0)
                    {
                        edge.Label = $"{Math.Round(Math.Abs(flow - flow2) / 2, 2)}/{edge.Weight}";
                        edge.EdgeColor = AlgoDefOptions.EdgeColor;
                    }
                }
            }

            EditAlgorithmNodes(startAlgorithm.StartNode, "Source", ref algorithmNodes);
            EditAlgorithmNodes(startAlgorithm.EndNode, "Sink", ref algorithmNodes);

            startAlgorithm.Output = Math.Round(max_flow, 2).ToString();
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

        public bool Boolbfs(double[,] rGraph, int s, int t, int[] parent, IList<AlgorithmNode> nodes)
        {
            bool[] visited = new bool[MaxId+1];
            foreach (AlgorithmNode a in nodes)
                visited[a.Node.NodeId] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;
 
            while (queue.Any())
            {
                int u = queue.Dequeue();

                foreach (AlgorithmNode a in nodes)
                {
                    if (visited[a.Node.NodeId] == false && rGraph[u, a.Node.NodeId] > 0)
                    {
                        queue.Enqueue(a.Node.NodeId);
                        parent[a.Node.NodeId] = u;
                        visited[a.Node.NodeId] = true;
                    }
                }
            }
            return (visited[t] == true);
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

        public Edge ConnectingEdge(DefaultOptions d, int tailId, int headId, IList<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                if ((edge.HeadNodeId == headId && edge.TailNodeId == tailId)
                    || (edge.HeadNodeId == tailId && edge.TailNodeId == headId && !d.Directed))
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
