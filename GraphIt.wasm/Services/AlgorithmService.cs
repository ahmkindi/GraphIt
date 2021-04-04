using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        private int MaxId { get; set; }
        public Options Options { get; set; }
        public StartAlgorithm StartAlgorithm { get; set; }
        public IList<List<GraphObject>> PlayAlgorithm { get; set; }
        public Graph Graph { get; set; }
        public AlgoExplain AlgoExplain { get; set; }
        int time = 0;
        public void RunAlgorithm(Options options, StartAlgorithm startAlgorithm, Graph graph, AlgoExplain algoExplain, ref List<List<GraphObject>> playAlgorithm)
        {
            Options = options;
            StartAlgorithm = startAlgorithm;
            Graph = graph;
            AlgoExplain = algoExplain;
            PlayAlgorithm = playAlgorithm;
            playAlgorithm.Clear();
            AlgoExplain.Explanations.Clear();
            AlgoExplain.Counter = 0;

            PlayAlgorithm.Add(new List<GraphObject>());
            foreach (Node node in Graph.Nodes) PlayAlgorithm[AlgoExplain.Counter].Add(new Node(node, options.Default));
            foreach (Edge edge in Graph.Edges) PlayAlgorithm[AlgoExplain.Counter].Add(new Edge(edge, options.Default, ""));
            MaxId = Graph.Nodes.Max(n => n.Id);
            Increment();

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
            AlgoExplain.MaxCounter = AlgoExplain.Counter;
            AlgoExplain.Counter = 0;
        }

        public void Kruskal()
        {
            double sum = 0;
            IEnumerable<Edge> sortedEdges = Graph.Edges.OrderBy(e => e.Weight);
            Set set = new Set(Graph.Nodes);
            
            foreach (Node node in Graph.Nodes)
            {
                set.MakeSet(node.Id);
                EditAlgorithmNodes(node, "set: " + node.Id.ToString());
            }
            AlgoExplain.Explanations.AddOrUpdate("Make a set for each node to start off", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
            Increment();

            IList<Edge> changeBack = new List<Edge>();
            foreach (Edge edge in sortedEdges)
            {
                foreach (Edge e in changeBack)
                {
                    EditAlgorithmEdges(e, Options.Default);
                }
                changeBack.Clear();

                if (set.FindSet(edge.Tail.Id) != set.FindSet(edge.Head.Id))
                {
                    EditAlgorithmEdges(edge, Options.Algorithm);
                    AlgoExplain.Explanations.AddOrUpdate("This is the smallest edge that connects different sets", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                    Increment();

                    sum += edge.Weight;
                    var x = set.Union(edge.Tail.Id, edge.Head.Id);

                    EditAlgorithmNodes(edge.Tail, "set: " + x);
                    EditAlgorithmNodes(edge.Head, "set: " + x);
                    AlgoExplain.Explanations.AddOrUpdate("Union the two sets", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                }
                else
                {
                    AlgoExplain.Explanations.AddOrUpdate("This edge connects the same set so it can't be chosen", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                    EditAlgorithmEdges(edge, Options.Algorithm);
                    changeBack.Add(edge);
                }
                Increment();
            }
            
            foreach (Edge e in changeBack)
            {
                EditAlgorithmEdges(e, Options.Default);
            }

            int max = 0;
            int min = int.MaxValue;
            foreach (Node node in Graph.Nodes)
            {
                var x = set.FindSet(node.Id);
                min = Math.Min(min, x);
                max = Math.Max(max, x);
            }
            if (min == max)
            {
                AlgoExplain.Explanations.AddOrUpdate("All Nodes belong to the same set, so MST is complete", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                StartAlgorithm.Output = $"Weight of MST is {sum}";
            }
            else
            {
                AlgoExplain.Explanations.AddOrUpdate("Not all nodes are in the same set => this graph is disconnected", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                StartAlgorithm.Output = "No tree Found";
            }
        }

        public void BFS()
        {
            Queue<NodeEdge> ToExplore = new Queue<NodeEdge>();
            IList<Node> Explored = new List<Node>();
            IList<Edge> TreeEdges = new List<Edge>();
            NodeEdge Exploring;
            int count = 0;
            EditAlgorithmNodes(StartAlgorithm.StartNode, "Source: " + count.ToString());
            AlgoExplain.Explanations.AddOrUpdate($"Enqueue Discovered Node to the Queue", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
            Increment();
            ToExplore.Enqueue(new NodeEdge(StartAlgorithm.StartNode));

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Dequeue();
                MakeNodeBlue(Exploring.Node, "Exploring");
                AlgoExplain.Explanations.AddOrUpdate($"Dequeue a Discovered Node To Explore its Neighbours", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                Increment();

                if (Explored.Contains(Exploring.Node))
                {
                    continue;
                }

                Explored.Add(Exploring.Node);

                foreach (NodeEdge neighbor in Adjacent(Exploring.Node.Id))
                {
                    if (!Explored.Contains(neighbor.Node)) 
                    {
                        count++;
                        ToExplore.Enqueue(neighbor);
                        EditAlgorithmEdges(neighbor.Edge, Options.Algorithm, "Tree Edge");
                        EditAlgorithmNodes(neighbor.Node, count.ToString());
                        AlgoExplain.Explanations.AddOrUpdate("This edge leads to an undiscovered node so its a tree edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                        TreeEdges.Add(neighbor.Edge);
                        Increment();
                    }
                    else if (Graph.Directed || !TreeEdges.Contains(neighbor.Edge))
                    {
                        EditAlgorithmEdges(neighbor.Edge, Options.Default, "Non-Tree Edge");
                        AlgoExplain.Explanations.AddOrUpdate("This edge leads to a discovered node so its a non-tree edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                        Increment();
                    }
                }
                EditAlgorithmNodes(Exploring.Node, Explored.IndexOf(Exploring.Node).ToString());
            }
            TraversalOutput(Explored);
        }

        public void DFS()
        {
            IList<Node> visited = new List<Node>();
            Dictionary<Node, int> pre = new Dictionary<Node, int>();
            Dictionary<Node, int> post = new Dictionary<Node, int>();
            time = 0;
            IList<Edge> treeEdges = new List<Edge>();
            DFSRun(StartAlgorithm.StartNode, pre, post, visited, treeEdges);
            TraversalOutput(visited);
        }

        public void DFSRun(Node u, Dictionary<Node, int> pre, Dictionary<Node, int> post, IList<Node> visited, IList<Edge> treeEdges)
        {
            pre[u] = time;
            MakeNodeBlue(u, $"[{time},-]");
            AlgoExplain.Explanations.AddOrUpdate("Preform DFS from this Node", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
            Increment();

            time++;
            visited.Add(u);
            foreach (NodeEdge neighbor in Adjacent(u.Id))
            {
                if (!visited.Contains(neighbor.Node))
                {
                    EditAlgorithmEdges(neighbor.Edge, Options.Algorithm, "tree edge");
                    AlgoExplain.Explanations.AddOrUpdate("This Edge Leads to an Undiscovered Node so its a Tree Edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                    Increment();
                    treeEdges.Add(neighbor.Edge);
                    DFSRun(neighbor.Node, pre, post, visited, treeEdges);
                }
                else if (Graph.Directed)
                {
                    
                    if (pre[u] < pre[neighbor.Node])
                    {
                        EditAlgorithmEdges(neighbor.Edge, Options.Default, "forward edge");
                        AlgoExplain.Explanations.AddOrUpdate("This node is a visited descendant, so forward edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                    }
                    else
                    {
                        if (post.ContainsKey(u) && !post.ContainsKey(neighbor.Node))
                        {
                            EditAlgorithmEdges(neighbor.Edge, Options.Default, "back edge");
                            AlgoExplain.Explanations.AddOrUpdate("This node is a visited ancestor, so back edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                        }
                        else
                        {
                            EditAlgorithmEdges(neighbor.Edge, Options.Default, "cross edge");
                            AlgoExplain.Explanations.AddOrUpdate("This node is visited and its neither descendant nor ancestor, so cross edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                        }
                    }
                    Increment();
                }
                else if (!treeEdges.Contains(neighbor.Edge))
                {
                    EditAlgorithmEdges(neighbor.Edge, Options.Default, "back edge");
                    AlgoExplain.Explanations.AddOrUpdate("This node is a visited ancestor, so back edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                    Increment();
                }

            }

            post[u] = time;
            EditAlgorithmNodes(u, $"[{pre[u]},{post[u]}]");
            AlgoExplain.Explanations.AddOrUpdate("This Node has no more edges to check, so backtrack", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
            Increment();
            time++;
        }

        public void Dijkstra()
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Node Exploring;
            foreach (Node node in Graph.Nodes)
            {
                if (node == StartAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in Graph.Nodes)
            {
                Exploring = ShortestDistance(Distances, Explored);
                Explored.Add(Exploring);
                foreach (KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(Exploring, kvp.Key);
                    double exploringDis = Distances[Exploring];
                    if (!Explored.Contains(kvp.Key) && connector != null
                        && exploringDis != double.MaxValue && exploringDis + connector.Weight < kvp.Value)
                    {
                        Distances[kvp.Key] = exploringDis + connector.Weight;
                    }
                }
            }

            foreach (KeyValuePair<Node, double> kvp in Distances)
            {
                if (kvp.Key.Id == StartAlgorithm.StartNode.Id) MakeNodeBlue(kvp.Key, $"Distance: {kvp.Value}");
                else EditAlgorithmNodes(kvp.Key, $"Distance: {kvp.Value}");
            }
        }

        public void DijkstraPath()
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Dictionary<Node, Edge> Path = new Dictionary<Node, Edge>();
            Node Exploring;
            foreach (Node node in Graph.Nodes)
            {
                if (node == StartAlgorithm.StartNode) Distances[node] = 0;
                else Distances[node] = double.MaxValue;
            }

            foreach (Node _ in Graph.Nodes)
            {
                Exploring = ShortestDistance(Distances, Explored);
                Explored.Add(Exploring);
                foreach (KeyValuePair<Node, double> kvp in Distances)
                {
                    Edge connector = ConnectingEdge(Exploring, kvp.Key);
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
                        MakeNodeBlue(nodeInPath, "");
                    else EditAlgorithmNodes(nodeInPath, "");
                    Edge edgeInPath = Path[nodeInPath];
                    totalLength += edgeInPath.Weight;
                    EditAlgorithmEdges(edgeInPath, Options.Algorithm);
                    Node prev = Path[nodeInPath].Tail;
                    if (prev == nodeInPath && !Graph.Directed) prev = Path[nodeInPath].Head;
                    nodeInPath = prev;
                    StartAlgorithm.Output = $"{nodeInPath.Label}=>{StartAlgorithm.Output}";
                }
                EditAlgorithmNodes(nodeInPath, "");
                StartAlgorithm.Output = $"Path length is {totalLength}: {StartAlgorithm.Output}";
            }
        }

        public void Degree()
        {
            int[] InDegreeCount = new int[MaxId + 1];
            int[] OutDegreeCount = new int[MaxId + 1];
            foreach (Node node in Graph.Nodes)
            {
                InDegreeCount[node.Id] = 0;
                OutDegreeCount[node.Id] = 0;
                if (Graph.Directed) EditAlgorithmNodes(node, $"Degree:{InDegreeCount[node.Id] + OutDegreeCount[node.Id]}");
                else EditAlgorithmNodes(node, $"In:{InDegreeCount[node.Id]}, Out:{OutDegreeCount[node.Id]}");
                AlgoExplain.Explanations.AddOrUpdate("Initialize all degrees to 0", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                Increment();
            }
            foreach (Edge edge in Graph.Edges)
            {
                OutDegreeCount[edge.Tail.Id]++;
                InDegreeCount[edge.Head.Id]++;
                EditAlgorithmEdges(edge, Options.Algorithm);
                if (Graph.Directed)
                {
                    EditAlgorithmNodes(edge.Tail, $"Degree:{InDegreeCount[edge.Tail.Id] + OutDegreeCount[edge.Tail.Id]}");
                    EditAlgorithmNodes(edge.Head, $"Degree:{InDegreeCount[edge.Head.Id] + OutDegreeCount[edge.Head.Id]}");
                }
                else 
                {
                    EditAlgorithmNodes(edge.Tail, $"In:{InDegreeCount[edge.Tail.Id]}, Out:{OutDegreeCount[edge.Tail.Id]}");
                    EditAlgorithmNodes(edge.Head, $"In:{InDegreeCount[edge.Head.Id]}, Out:{OutDegreeCount[edge.Head.Id]}");
                } 
                AlgoExplain.Explanations.AddOrUpdate("Increment the degree of the nodes incident to this edge", new List<int> { AlgoExplain.Counter }, (key, list) => Update(list));
                Increment();
                EditAlgorithmEdges(edge, Options.Default);
            }
        }

        public void DegreeCentrality(string pref)
        {
            int[] DegreeCount = new int[MaxId+1];
            foreach (Node node in Graph.Nodes) DegreeCount[node.Id] = 0;
            foreach (Edge edge in Graph.Edges)
            {
                if (pref == "in")
                    DegreeCount[edge.Head.Id]++;
                else if (pref == "out")
                    DegreeCount[edge.Tail.Id]++;
                else if (pref == "both")
                {
                    DegreeCount[edge.Tail.Id]++;
                    DegreeCount[edge.Head.Id]++;
                }
            }

            double maxWeight = DegreeCount.Max();
            double minWeight = DegreeCount.Min();
            foreach (Node node in Graph.Nodes)
            {
                double normalizedWeight = (DegreeCount[node.Id] - minWeight) / (maxWeight - minWeight);
                EditAlgorithmNodes(node, (int)(normalizedWeight * (150 - 25) + 25));
            }
        }

        public void FordFulkerson()
        {
            int u, v;
            double[,] rGraph = new double[MaxId + 1, MaxId + 1];
            HashSet<Node> nodesUsed = new HashSet<Node>();


            foreach (Node n1 in Graph.Nodes)
            {
                foreach (Node n2 in Graph.Nodes)
                {
                    Edge adj = ConnectingEdge(n1, n2);
                    if (adj == null)
                        rGraph[n1.Id, n2.Id] = 0;
                    else rGraph[n1.Id, n2.Id] = adj.Weight;
                }
            }

            int[] parent = new int[MaxId + 1];

            double max_flow = 0;

            while (Boolbfs(rGraph, StartAlgorithm.StartNode.Id, StartAlgorithm.EndNode.Id, parent))
            {
                double path_flow = double.MaxValue;
                for (v = StartAlgorithm.EndNode.Id; v != StartAlgorithm.StartNode.Id; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                for (v = StartAlgorithm.EndNode.Id; v != StartAlgorithm.StartNode.Id; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                max_flow += path_flow;
            }
            if (Graph.Directed)
            {
                foreach (Edge edge in Graph.Edges)
                {
                    double flow = rGraph[edge.Head.Id, edge.Tail.Id];
                    if (flow > 0)
                    {
                        EditAlgorithmEdges(edge, Options.Algorithm, $"{flow}/{edge.Weight}");
                        nodesUsed.Add(edge.Head);
                        nodesUsed.Add(edge.Tail);
                    }
                }
            }
            else
            {
                foreach (Edge edge in Graph.Edges)
                {
                    double flow = rGraph[edge.Head.Id, edge.Tail.Id];
                    double flow2 = rGraph[edge.Tail.Id, edge.Head.Id];
                    if (Math.Abs(flow - flow2) > 0)
                    {
                        EditAlgorithmEdges(edge, Options.Algorithm, $"{Math.Round(Math.Abs(flow - flow2) / 2, 2)}/{edge.Weight}");
                        nodesUsed.Add(edge.Head);
                        nodesUsed.Add(edge.Tail);
                    }
                }
            }
            foreach (Node node in nodesUsed)
                EditAlgorithmNodes(node, "");
            MakeNodeBlue(StartAlgorithm.StartNode, "Source");
            MakeNodeBlue(StartAlgorithm.EndNode, "Sink");

            StartAlgorithm.Output = $"Maximum Flow = {Math.Round(max_flow, 2)}";
        }

        public void Articulation()
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[MaxId + 1];
            int[] disc = new int[MaxId + 1];
            int[] low = new int[MaxId + 1];
            int[] parent = new int[MaxId + 1];
            bool[] ap = new bool[MaxId + 1]; // To store articulation points 

            // Initialize parent and visited, and  
            // ap(articulation point) arrays 
            foreach (Node node in Graph.Nodes)
            {
                parent[node.Id] = -1;
                visited[node.Id] = false;
                ap[node.Id] = false;
            }

            // Call the recursive helper function to find articulation 
            // points in DFS tree rooted with vertex 'i' 
            foreach (Node node in Graph.Nodes)
                if (!visited[node.Id])
                    APUtil(node.Id, visited, disc, low, parent, ap);

            // Now ap[] contains articulation points, print them
            int count = 0;
            foreach (Node node in Graph.Nodes)
                if (ap[node.Id])
                {
                    EditAlgorithmNodes(node, "");
                    count++;
                }
            StartAlgorithm.Output = $"{count} Articulation Points Found";
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

            // Go through all vertices adjacent to this 
            foreach (NodeEdge nodeEdge in Adjacent(u))
            {
                int v = nodeEdge.Node.Id; // v is current adjacent of u 

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
            Node newNode = new Node(node, Options.Algorithm, header);
            PlayAlgorithm[AlgoExplain.Counter].Add(newNode);
        }
        public void EditAlgorithmNodes(Node node, int size)
        {
            Node newNode = new Node(node, Options.Algorithm);
            newNode.Size = size;
            PlayAlgorithm[AlgoExplain.Counter].Add(newNode);
        }

        public void MakeNodeBlue(Node node, string header)
        {
            Node newNode = new Node(node);
            newNode.Header = header;
            newNode.Color = "#0000ff";
            newNode.LabelColor = "#ffffff";
            PlayAlgorithm[AlgoExplain.Counter].Add(newNode);
        }

        public void EditAlgorithmEdges(Edge edge, DefaultOptions d)
        {
            Edge newEdge = new Edge(edge, d);
            PlayAlgorithm[AlgoExplain.Counter].Add(newEdge);
        }

        public void EditAlgorithmEdges(Edge edge, DefaultOptions d, string label)
        {
            Edge newEdge = new Edge(edge, d);
            newEdge.Label = label;
            PlayAlgorithm[AlgoExplain.Counter].Add(newEdge);
        }

        public bool Boolbfs(double[,] rGraph, int s, int t, int[] parent)
        {
            bool[] visited = new bool[MaxId + 1];
            foreach (Node node in Graph.Nodes)
                visited[node.Id] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            while (queue.Any())
            {
                int u = queue.Dequeue();

                foreach (Node node in Graph.Nodes)
                {
                    if (visited[node.Id] == false && rGraph[u, node.Id] > 0)
                    {
                        queue.Enqueue(node.Id);
                        parent[node.Id] = u;
                        visited[node.Id] = true;
                    }
                }
            }
            return (visited[t] == true);
        }

        public IList<NodeEdge> Adjacent(int id)
        {
            var adj = new List<NodeEdge>();
            foreach (Edge edge in Graph.Edges.Where(e => e.Tail.Id == id))
            {
                adj.Add(new NodeEdge(Graph.Nodes.First(n => n == edge.Head), edge));
            }
            if (!Graph.Directed)
            {
                foreach (Edge edge in Graph.Edges.Where(e => e.Head.Id == id))
                {
                    adj.Add(new NodeEdge(Graph.Nodes.First(n => n == edge.Tail), edge));
                }
            }
            return adj.OrderBy(n => n.Node.Id).ToList();
        }

        public Edge ConnectingEdge(Node tail, Node head)
        {
            foreach (Edge edge in Graph.Edges)
            {
                if ((edge.Head == head && edge.Tail == tail)
                    || (edge.Head == tail && edge.Tail == head && !Graph.Directed))
                {
                    return edge;
                }
            }
            return null;
        }

        public Node ShortestDistance(Dictionary<Node, double> distances, IList<Node> explored)
        {
            Node closest = null;
            foreach (KeyValuePair<Node, double> kvp in distances)
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

        public List<int> Update(List<int> list)
        {
            list.Add(AlgoExplain.Counter);
            return list;
        }

        public void Increment()
        {
            PlayAlgorithm.Add(new List<GraphObject>());
            AlgoExplain.Counter++;
        }

    }
}
