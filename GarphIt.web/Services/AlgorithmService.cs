using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private int MaxId { get; set; }
        public DefaultOptions DefaultAlgoOptions { get; set; }
        public DefaultOptions DefaultOptions { get; set; }
        public StartAlgorithm StartAlgorithm { get; set; }
        public IList<AlgorithmNode> AlgorithmNodes { get; set; }
        public IList<Edge> AlgorithmEdges { get; set; }
        public IList<Node> Nodes { get; set; }
        public IList<Edge> Edges { get; set; }
        public void RunAlgorithm(DefaultOptions d, DefaultOptions a, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, IList<Edge> edges, ref IList<Edge> algorithmEdges)
        {
            DefaultAlgoOptions = a;
            DefaultOptions = d;
            StartAlgorithm = startAlgorithm;
            Nodes = nodes;
            Edges = edges;
            AlgorithmNodes = algorithmNodes;
            AlgorithmEdges = algorithmEdges;
            AlgorithmNodes.Clear();
            AlgorithmEdges.Clear();
            foreach (Node node in nodes) AlgorithmNodes.Add(new AlgorithmNode(node));
            foreach (Edge edge in edges) AlgorithmEdges.Add(new Edge(edge));
            MaxId = nodes.Max(n => n.NodeId);
            
            switch (StartAlgorithm.Algorithm)
            {
                case Algorithm.Kruskal:
                    Kruskal();
                    break;
                case Algorithm.BFS:
                    BFS();
                    break;
                case Algorithm.DFS:
                    DFS();
                    break;
                case Algorithm.Dijkstra:
                    Dijkstra();
                    break;
                case Algorithm.DijkstraPath:
                    DijkstraPath();
                    break;
                case Algorithm.Degree:
                    Degree();
                    break;
                case Algorithm.DegreeCentrality:
                    DegreeCentrality();
                    break;
                case Algorithm.MaxFlow:
                    FordFulkerson();
                    break;
            }
            StartAlgorithm.Done = true;
        }

        public void Kruskal()
        {
            AlgorithmEdges.Clear();
            IEnumerable<Edge> sortedEdges = Edges.OrderBy(e => e.Weight);
            Set set = new Set(Nodes);
            
            foreach (Node node in Nodes)
                set.MakeSet(node.NodeId);

            foreach (Edge edge in sortedEdges)
            {
                if (set.FindSet(edge.TailNodeId) != set.FindSet(edge.HeadNodeId))
                {
                    AlgorithmEdges.Add(edge);
                    set.Union(edge.TailNodeId, edge.HeadNodeId);
                }
            }
        }

        public void BFS()
        {
            Queue<NodeEdge> ToExplore = new Queue<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            ToExplore.Enqueue(new NodeEdge(StartAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Dequeue();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node);
                EditAlgorithmNodes(Exploring.Node, count.ToString());
                if (count > 1)
                    EditAlgorithmEdges(Exploring.Edge);

                count++;

                foreach (NodeEdge neighbor in Adjacent(Exploring.Node))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Enqueue(neighbor);
                }
            }
        }

        public void DFS()
        {
            Stack<NodeEdge> ToExplore = new Stack<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            ToExplore.Push(new NodeEdge(StartAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Pop();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node);
                EditAlgorithmNodes(Exploring.Node, count.ToString());
                if (count > 1)
                    EditAlgorithmEdges(Exploring.Edge);

                count++;

                foreach (NodeEdge neighbor in Adjacent(Exploring.Node))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Push(neighbor);
                }
            }
        }

        public void Dijkstra()
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Node Exploring;
            foreach(Node node in Nodes)
            {
                if (node == StartAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in Nodes)
            {
                Exploring = ShortestDistance(Distances, Explored);
                Explored.Add(Exploring);
                foreach(KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(Exploring.NodeId, kvp.Key.NodeId);
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
                EditAlgorithmNodes(kvp.Key, $"Distance: {kvp.Value}");
            }
        }

        public void DijkstraPath()
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Dictionary<Node, Edge> Path = new Dictionary<Node, Edge>();
            Node Exploring;
            foreach (Node node in Nodes)
            {
                if (node == StartAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in Nodes)
            {
                Exploring = ShortestDistance(Distances, Explored);
                Explored.Add(Exploring);
                foreach (KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(Exploring.NodeId, kvp.Key.NodeId);
                    double exploringDis = Distances[Exploring];
                    if (!Explored.Contains(kvp.Key) && connector != null
                        && exploringDis != double.MaxValue && exploringDis + connector.Weight < kvp.Value)
                    {
                        Distances[kvp.Key] = exploringDis + connector.Weight;
                        Path[kvp.Key] = connector;
                    }
                }
            }

            if (!Path.ContainsKey(StartAlgorithm.EndNode))
                StartAlgorithm.Output = "No Path Exists";
            else
            {
                Node nodeInPath = StartAlgorithm.EndNode;
                while (nodeInPath != StartAlgorithm.StartNode)
                {
                    Edge edgeInPath = Path[nodeInPath];
                    EditAlgorithmNodes(nodeInPath, "");
                    EditAlgorithmEdges(edgeInPath);
                    Node prev = Path[nodeInPath].TailNode(Nodes);
                    if (prev == nodeInPath && !DefaultOptions.Directed) prev = Path[nodeInPath].HeadNode(Nodes);
                    nodeInPath = prev;
                }
                EditAlgorithmNodes(nodeInPath, "");
            }
        }

        public void Degree()
        {
            Dictionary<int, int> DegreeCount = new Dictionary<int, int>();
            foreach (AlgorithmNode an in AlgorithmNodes) DegreeCount[an.Node.NodeId] = 0;
            foreach (Edge edge in AlgorithmEdges)
            {
                DegreeCount[edge.TailNodeId]++;
                if (!DefaultOptions.Directed) DegreeCount[edge.TailNodeId]++;
            }
            foreach (AlgorithmNode an in AlgorithmNodes) an.Header = DegreeCount[an.Node.NodeId].ToString();
        }

        public void DegreeCentrality()
        {
            Dictionary<int, int> DegreeCount = new Dictionary<int, int>();
            double maxWeight = 1;
            double minWeight = 0;
            foreach (AlgorithmNode an in AlgorithmNodes) DegreeCount[an.Node.NodeId] = 0;
            foreach (Edge edge in AlgorithmEdges)
            {
                DegreeCount[edge.TailNodeId]++;
                DegreeCount[edge.HeadNodeId]++;
                maxWeight = Math.Max(maxWeight, edge.Weight);
                if (minWeight == 0) minWeight = edge.Weight;
                else minWeight = Math.Min(minWeight, edge.Weight);
            }
            foreach (Edge edge in AlgorithmEdges)
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
            foreach (AlgorithmNode an in AlgorithmNodes)
            {
                double normalizedWeight = (DegreeCount[an.Node.NodeId] - minWeight) / (maxWeight - minWeight);
                an.Node.Radius = Math.Max(10, (int)normalizedWeight * 100);
            }
        }

        public void FordFulkerson()
        {
            int u, v;
            double[,] rGraph = new double[MaxId+1, MaxId+1];

            foreach (AlgorithmNode a1 in AlgorithmNodes)
            {
                foreach (AlgorithmNode a2 in AlgorithmNodes)
                {
                    Edge adj = ConnectingEdge(a1.Node.NodeId, a2.Node.NodeId);
                    if (adj == null)
                        rGraph[a1.Node.NodeId, a2.Node.NodeId] = 0;
                    else rGraph[a1.Node.NodeId, a2.Node.NodeId] = adj.Weight;
                }
            }

            int[] parent = new int[MaxId+1];

            double max_flow = 0;

            while (Boolbfs(rGraph, StartAlgorithm.StartNode.NodeId, StartAlgorithm.EndNode.NodeId, parent))
            {
                double path_flow = double.MaxValue;
                for (v = StartAlgorithm.EndNode.NodeId; v != StartAlgorithm.StartNode.NodeId; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                for (v = StartAlgorithm.EndNode.NodeId; v != StartAlgorithm.StartNode.NodeId; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                max_flow += path_flow;
            }
            if (DefaultOptions.Directed)
            {
                foreach (Edge edge in AlgorithmEdges)
                {
                    double flow = rGraph[edge.HeadNodeId, edge.TailNodeId];
                    if (flow > 0)
                    {
                        edge.Label = $"{flow}/{edge.Weight}";
                        edge.EdgeColor = DefaultAlgoOptions.EdgeColor;
                    }
                }
            }
            else
            {
                foreach (Edge edge in AlgorithmEdges)
                {
                    double flow = rGraph[edge.HeadNodeId, edge.TailNodeId];
                    double flow2 = rGraph[edge.TailNodeId, edge.HeadNodeId];
                    if (Math.Abs(flow - flow2) > 0)
                    {
                        edge.Label = $"{Math.Round(Math.Abs(flow - flow2) / 2, 2)}/{edge.Weight}";
                        edge.EdgeColor = DefaultAlgoOptions.EdgeColor;
                    }
                }
            }

            EditAlgorithmNodes(StartAlgorithm.StartNode, "Source");
            EditAlgorithmNodes(StartAlgorithm.EndNode, "Sink");

            StartAlgorithm.Output = Math.Round(max_flow, 2).ToString();
        }


        public void EditAlgorithmNodes(Node node, string header)
        {
            AlgorithmNode nodeEditing = AlgorithmNodes.First(n => n.Node.NodeId == node.NodeId);
            nodeEditing.Header = header;
            nodeEditing.Node.NodeColor = DefaultAlgoOptions.NodeColor;
            nodeEditing.Node.LabelColor = DefaultAlgoOptions.NodeLabelColor;
        }

        public void EditAlgorithmEdges(Edge edge)
        {
            Edge edgeEditing = AlgorithmEdges.First(e => e.EdgeId == edge.EdgeId);
            edgeEditing.EdgeColor = DefaultAlgoOptions.EdgeColor;
            edgeEditing.LabelColor = DefaultAlgoOptions.EdgeLabelColor;
        }

        public bool Boolbfs(double[,] rGraph, int s, int t, int[] parent)
        {
            bool[] visited = new bool[MaxId+1];
            foreach (AlgorithmNode a in AlgorithmNodes)
                visited[a.Node.NodeId] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;
 
            while (queue.Any())
            {
                int u = queue.Dequeue();

                foreach (AlgorithmNode a in AlgorithmNodes)
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

        public IList<NodeEdge> Adjacent(Node node)
        {
            var adj = new List<NodeEdge>();
            foreach(Edge edge in Edges.Where(e => e.TailNodeId == node.NodeId)) 
            {
                adj.Add(new NodeEdge(Nodes.First(n => n.NodeId == edge.HeadNodeId), edge));
            }
            if (!DefaultOptions.Directed)
            {
                foreach (Edge edge in Edges.Where(e => e.HeadNodeId == node.NodeId))
                {
                    adj.Add(new NodeEdge(Nodes.First(n => n.NodeId == edge.TailNodeId), edge));
                }
            }
            return adj;
        }

        public Edge ConnectingEdge(int tailId, int headId)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.HeadNodeId == headId && edge.TailNodeId == tailId)
                    || (edge.HeadNodeId == tailId && edge.TailNodeId == headId && !DefaultOptions.Directed))
                {
                    return edge;
                }
            }
            return null;
        }

        public Node ShortestDistance(Dictionary<Node, double> distances, IList<Node> explored)
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
