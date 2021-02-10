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
                case Algorithm.BFS:
                    BFS(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.DFS:
                    DFS(d, startAlgorithm, nodes, ref algorithmNodes, ref algorithmEdges);
                    break;
                case Algorithm.Dijkstra:
                    break;
            }
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
    }
}
