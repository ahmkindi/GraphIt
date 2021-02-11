using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class AlgorithmService : IAlgorithmService
    {
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
            Queue<Node> ToExplore = new Queue<Node>();
            IList<Node> Explored = new List<Node>();
            Node Exploring;
            int count = 1;
            ToExplore.Enqueue(startAlgorithm.StartNode);
            while (ToExplore.Any())
            {
                Exploring = ToExplore.Dequeue();
                if (Explored.Contains(Exploring))
                    continue;

                Explored.Add(Exploring);
                algorithmNodes.First(n => n.Node == Exploring).Header = count.ToString();
                count++;

                foreach (Node neighbor in Adjacent(d, Exploring, nodes, algorithmEdges))
                {
                    if (!Explored.Contains(neighbor))
                        ToExplore.Enqueue(neighbor);
                }
            }
            startAlgorithm.Done = true;
        }

        public void DFS(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            Stack<Node> ToExplore = new Stack<Node>();
            IList<Node> Explored = new List<Node>();
            Node Exploring;
            int count = 1;
            ToExplore.Push(startAlgorithm.StartNode);

            while (ToExplore.Any())
            {
                Exploring = ToExplore.Pop();
                if (Explored.Contains(Exploring))
                    continue;

                Explored.Add(Exploring);
                algorithmNodes.First(n => n.Node == Exploring).Header = count.ToString();
                count++;

                foreach (Node neighbor in Adjacent(d, Exploring, nodes, algorithmEdges))
                {
                    if (!Explored.Contains(neighbor))
                        ToExplore.Push(neighbor);
                }
            }
            startAlgorithm.Done = true;
        }

        public void Dijkstra(DefaultOptions d, StartAlgorithm startAlgorithm, IList<Node> nodes, ref IList<AlgorithmNode> algorithmNodes, ref IList<Edge> algorithmEdges)
        {
            IList<Node> Explored = new List<Node>();
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            Dictionary<Node, Edge> Path = new Dictionary<Node, Edge>();
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
                        Path[kvp.Key] = connector;
                    }
                }
            }

            foreach(KeyValuePair<Node, double> kvp in Distances)
            {
                var edit = algorithmNodes.First(n => n.Node == kvp.Key);
                edit.Header = $"Distance From Start: {kvp.Value}";
            }

            startAlgorithm.Done = true;
        }

        public IList<Node> Adjacent(DefaultOptions d, Node node, IList<Node> nodes, IList<Edge> edges)
        {
            var adj = new List<Node>();
            foreach(Edge edge in edges.Where(e => e.TailNodeId == node.NodeId)) 
            {
                adj.Add(nodes.First(n => n.NodeId == edge.HeadNodeId));
            }
            if (!d.Directed)
            {
                foreach (Edge edge in edges.Where(e => e.HeadNodeId == node.NodeId))
                {
                    adj.Add(nodes.First(n => n.NodeId == edge.TailNodeId));
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
