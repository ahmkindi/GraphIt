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
        int time = 0;
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
            foreach (Node node in nodes) AlgorithmNodes.Add(new AlgorithmNode(node, d));
            foreach (Edge edge in edges) AlgorithmEdges.Add(new Edge(edge, d));
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
                case Algorithm.MaxFlow:
                    FordFulkerson();
                    break;
                case Algorithm.Degree:
                    Degree();
                    break;
                case Algorithm.DegreeCentrality:
                    DegreeCentrality("both");
                    break;
                case Algorithm.InDegreeCentrality:
                    DegreeCentrality("in");
                    break;
                case Algorithm.OutDegreeCentrality:
                    DegreeCentrality("out");
                    break;
                case Algorithm.Articulation:
                    Articulation();
                    break;
            }
            StartAlgorithm.Done = true;
        }

        public void Kruskal()
        {
            double sum = 0;
            IEnumerable<Edge> sortedEdges = Edges.OrderBy(e => e.Weight);
            Set set = new Set(Nodes);
            
            foreach (Node node in Nodes)
                set.MakeSet(node.NodeId);

            foreach (Edge edge in sortedEdges)
            {
                if (set.FindSet(edge.TailNodeId) != set.FindSet(edge.HeadNodeId))
                {
                    sum += edge.Weight;
                    EditAlgorithmEdges(edge);
                    set.Union(edge.TailNodeId, edge.HeadNodeId);
                }
            }
            StartAlgorithm.Output = $"Weight of MST is {sum}";
        }

        public void BFS()
        {
            Queue<NodeEdge> ToExplore = new Queue<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            EditAlgorithmNodes(StartAlgorithm.StartNode, count.ToString(), "");
            ToExplore.Enqueue(new NodeEdge(StartAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Dequeue();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node);
                
                if (count > 1)
                {
                    EditAlgorithmEdges(Exploring.Edge);
                    EditAlgorithmNodes(Exploring.Node, count.ToString());
                }

                count++;

                foreach (NodeEdge neighbor in Adjacent(Exploring.Node.NodeId))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Enqueue(neighbor);
                }
            }
            TraversalOutput(Explored);
        }

        public void DFS()
        {
            Stack<NodeEdge> ToExplore = new Stack<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            NodeEdge Exploring;
            int count = 1;
            EditAlgorithmNodes(StartAlgorithm.StartNode, count.ToString(), "");
            ToExplore.Push(new NodeEdge(StartAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Pop();
                if (Explored.Contains(Exploring.Node))
                    continue;

                Explored.Add(Exploring.Node); 

                if (count > 1)
                {
                    EditAlgorithmEdges(Exploring.Edge);
                    EditAlgorithmNodes(Exploring.Node, count.ToString());
                }

                count++;

                foreach (NodeEdge neighbor in Adjacent(Exploring.Node.NodeId))
                {
                    if (!Explored.Contains(neighbor.Node))
                        ToExplore.Push(neighbor);
                }
            }

            TraversalOutput(Explored);
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
                if (kvp.Key.NodeId == StartAlgorithm.StartNode.NodeId) EditAlgorithmNodes(kvp.Key, $"Distance: {kvp.Value}", "");
                else EditAlgorithmNodes(kvp.Key, $"Distance: {kvp.Value}");
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
            double totalLength = 0;
            if (!Path.ContainsKey(StartAlgorithm.EndNode))
                StartAlgorithm.Output = "No Path Exists";
            else
            {
                Node nodeInPath = StartAlgorithm.EndNode;
                StartAlgorithm.Output = nodeInPath.Label;
                while (nodeInPath != StartAlgorithm.StartNode)
                {
                    if (nodeInPath == StartAlgorithm.EndNode)
                        EditAlgorithmNodes(nodeInPath, "", "");
                    else EditAlgorithmNodes(nodeInPath, "");
                    Edge edgeInPath = Path[nodeInPath];
                    totalLength += edgeInPath.Weight;
                    EditAlgorithmEdges(edgeInPath);
                    Node prev = Path[nodeInPath].TailNode(Nodes);
                    if (prev == nodeInPath && !DefaultOptions.Directed) prev = Path[nodeInPath].HeadNode(Nodes);
                    nodeInPath = prev;
                    StartAlgorithm.Output = $"{nodeInPath.Label}=>{StartAlgorithm.Output}";
                }
                EditAlgorithmNodes(nodeInPath, "", "");
                StartAlgorithm.Output = $"Path length is {totalLength}: {StartAlgorithm.Output}";
            }
        }

        public void Degree()
        {
            Dictionary<int, int> InDegreeCount = new Dictionary<int, int>();
            Dictionary<int, int> OutDegreeCount = new Dictionary<int, int>();
            foreach (AlgorithmNode an in AlgorithmNodes) 
            {
                InDegreeCount[an.Node.NodeId] = 0;
                OutDegreeCount[an.Node.NodeId] = 0;
            } 
            foreach (Edge edge in AlgorithmEdges)
            {
                OutDegreeCount[edge.TailNodeId]++;
                InDegreeCount[edge.HeadNodeId]++;
            }
            if (DefaultOptions.Directed)
                foreach (AlgorithmNode an in AlgorithmNodes)
                    an.Header = $"In-Degree:{InDegreeCount[an.Node.NodeId]}\nOut-Degree:{OutDegreeCount[an.Node.NodeId]}";
            else
                foreach (AlgorithmNode an in AlgorithmNodes)
                    an.Header = $"Degree:{InDegreeCount[an.Node.NodeId]+OutDegreeCount[an.Node.NodeId]}";
        }

        public void DegreeCentrality(string pref)
        {
            Dictionary<int, int> DegreeCount = new Dictionary<int, int>();
            double maxWeight = 0;
            double minWeight = -1;
            foreach (AlgorithmNode an in AlgorithmNodes) DegreeCount[an.Node.NodeId] = 0;
            foreach (Edge edge in AlgorithmEdges)
            {
                if (pref == "in")
                    DegreeCount[edge.HeadNodeId]++;
                else if (pref == "out")
                    DegreeCount[edge.TailNodeId]++;
                else if (pref == "both")
                {
                    DegreeCount[edge.TailNodeId]++;
                    DegreeCount[edge.HeadNodeId]++;
                }
            }
            foreach (KeyValuePair<int, int> kvp in DegreeCount) 
            {
                maxWeight = Math.Max(kvp.Value, maxWeight);
                if (minWeight == -1) minWeight = kvp.Value;
                else minWeight = Math.Min(minWeight, kvp.Value);
            }
            foreach (AlgorithmNode an in AlgorithmNodes)
            {
                double normalizedWeight = (DegreeCount[an.Node.NodeId] - minWeight) / (maxWeight - minWeight);
                an.Node.Radius = (int) (normalizedWeight * (150 - 25) + 25);
            }
        }

        public void FordFulkerson()
        {
            int u, v;
            double[,] rGraph = new double[MaxId+1, MaxId+1];
            HashSet<int> nodesUsed = new HashSet<int>();
            

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
                        nodesUsed.Add(edge.HeadNodeId);
                        nodesUsed.Add(edge.TailNodeId);
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
                        nodesUsed.Add(edge.HeadNodeId);
                        nodesUsed.Add(edge.TailNodeId);
                    }
                }
            }
            foreach (int i in nodesUsed)
                EditAlgorithmNodes(i, "");
            EditAlgorithmNodes(StartAlgorithm.StartNode, "Source", "");
            EditAlgorithmNodes(StartAlgorithm.EndNode, "Sink", "");

            StartAlgorithm.Output = $"Maximum Flow = {Math.Round(max_flow, 2)}";
        }

        public void Articulation()
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[MaxId+1];
            int[] disc = new int[MaxId+1];
            int[] low = new int[MaxId+1];
            int[] parent = new int[MaxId+1];
            bool[] ap = new bool[MaxId+1]; // To store articulation points 

            // Initialize parent and visited, and  
            // ap(articulation point) arrays 
            foreach (Node node in Nodes)
            {
                parent[node.NodeId] = -1;
                visited[node.NodeId] = false;
                ap[node.NodeId] = false;
            }

            // Call the recursive helper function to find articulation 
            // points in DFS tree rooted with vertex 'i' 
            foreach (Node node in Nodes)
                if (visited[node.NodeId] == false)
                    APUtil(node.NodeId, visited, disc, low, parent, ap);

            // Now ap[] contains articulation points, print them 
            foreach (Node node in Nodes)
                if (ap[node.NodeId] == true)
                    EditAlgorithmNodes(node, "");
        }

        // A recursive function that find articulation points using DFS 
        // u --> The vertex to be visited next 
        // visited[] --> keeps tract of visited vertices 
        // disc[] --> Stores discovery times of visited vertices 
        // parent[] --> Stores parent vertices in DFS tree 
        // ap[] --> Store articulation points 
        void APUtil(int u, bool[] visited, int[] disc,
                    int[] low, int[] parent, bool[] ap)
        {

            // Count of children in DFS Tree 
            int children = 0;

            // Mark the current node as visited 
            visited[u] = true;

            // Initialize discovery time and low value 
            disc[u] = low[u] = ++time;

            // Go through all vertices aadjacent to this 
            foreach (NodeEdge nodeEdge in Adjacent(u))
            {
                int v = nodeEdge.Node.NodeId; // v is current adjacent of u 

                // If v is not visited yet, then make it a child of u 
                // in DFS tree and recur for it 
                if (!visited[v])
                {
                    children++;
                    parent[v] = u;
                    APUtil(v, visited, disc, low, parent, ap);

                    // Check if the subtree rooted with v has  
                    // a connection to one of the ancestors of u 
                    low[u] = Math.Min(low[u], low[v]);

                    // u is an articulation point in following cases 

                    // (1) u is root of DFS tree and has two or more chilren. 
                    if (parent[u] == -1 && children > 1)
                        ap[u] = true;

                    // (2) If u is not root and low value of one of its child 
                    // is more than discovery value of u. 
                    if (parent[u] != -1 && low[v] >= disc[u])
                        ap[u] = true;
                }

                // Update low value of u for parent function calls. 
                else if (v != parent[u])
                    low[u] = Math.Min(low[u], disc[v]);
            }
        }

        public void EditAlgorithmNodes(Node node, string header)
        {
            AlgorithmNode nodeEditing = AlgorithmNodes.First(n => n.Node.NodeId == node.NodeId);
            nodeEditing.Header = header;
            nodeEditing.Node.NodeColor = DefaultAlgoOptions.NodeColor;
            nodeEditing.Node.LabelColor = DefaultAlgoOptions.NodeLabelColor;
        }

        public void EditAlgorithmNodes(int id, string header)
        {
            AlgorithmNode nodeEditing = AlgorithmNodes.First(n => n.Node.NodeId == id);
            nodeEditing.Header = header;
            nodeEditing.Node.NodeColor = DefaultAlgoOptions.NodeColor;
            nodeEditing.Node.LabelColor = DefaultAlgoOptions.NodeLabelColor;
        }

        public void EditAlgorithmNodes(Node node, string header, string _)
        {
            AlgorithmNode nodeEditing = AlgorithmNodes.First(n => n.Node.NodeId == node.NodeId);
            nodeEditing.Header = header;
            nodeEditing.Node.NodeColor = "#0000ff";
            nodeEditing.Node.LabelColor = "#ffffff";
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

        public IList<NodeEdge> Adjacent(int id)
        {
            var adj = new List<NodeEdge>();
            foreach(Edge edge in Edges.Where(e => e.TailNodeId == id)) 
            {
                adj.Add(new NodeEdge(Nodes.First(n => n.NodeId == edge.HeadNodeId), edge));
            }
            if (!DefaultOptions.Directed)
            {
                foreach (Edge edge in Edges.Where(e => e.HeadNodeId == id))
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

        public void TraversalOutput(IList<Node> explored)
        {
            int count;
            StartAlgorithm.Output = "Traversal Order: ";
            IList<string> labelsUsed = new List<string>();
            foreach (Node node in explored)
            {
                StartAlgorithm.Output += node.Label;
                count = labelsUsed.Where(s => s == node.Label).Count();
                if (count > 0) StartAlgorithm.Output += $"[{count}]";
                StartAlgorithm.Output += " ";
                labelsUsed.Add(node.Label);
            }
        }

    }
}
