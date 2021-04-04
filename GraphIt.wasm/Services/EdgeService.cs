using GraphIt.wasm.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public class EdgeService : IEdgeService
    {
        public Edge AddEdge(IList<Edge> edges, DefaultOptions d, Node head, Node tail, double weight)
        {
            Edge edge = new Edge
            {
                Id = NextId(edges),
                LabelColor = d.EdgeLabelColor,
                Color = d.EdgeColor,
                Head = head,
                Tail = tail,
                Size = d.EdgeWidth,
                Weight = weight
            };
            edges.Add(edge);
            return edge;
        }
        public Edge AddEdge(IList<Edge> edges, DefaultOptions d, Node head, Node tail)
        {
            Edge edge = new Edge
            {
                Id = NextId(edges),
                LabelColor = d.EdgeLabelColor,
                Color = d.EdgeColor,
                Head = head,
                Tail = tail,
                Size = d.EdgeWidth,
            };
            edges.Add(edge);
            return edge;
        }

        public Edge AddEdge(IList<Edge> edges, Edge e)
        {
            Edge edge = new Edge
            {
                Id = NextId(edges),
                LabelColor = e.LabelColor,
                Color = e.Color,
                Head = e.Head,
                Tail = e.Tail,
                Size = e.Size,
                Curve = e.Curve,
                Weight = e.Weight
            };
            edges.Add(edge);
            return edge;
        }

        public Edge AddEdge(Graph graph, Edge e, int id)
        {
            Edge edge = new Edge
            {
                Id = NextId(graph.Edges),
                LabelColor = e.LabelColor,
                Color = e.Color,
                Head = graph.Nodes.First(n => n.Id == (id + e.Head.Id)),
                Tail = graph.Nodes.First(n => n.Id == (id + e.Tail.Id)),
                Size = e.Size,
                Curve = e.Curve,
                Weight = e.Weight
            };
            graph.Edges.Add(edge);
            return edge;
        }

        public void DeleteEdges(List<Edge> edges, IList<Edge> edgesToDel)
        {
            edges.RemoveAll(e => edgesToDel.Contains(e));
        }

        public void UpdateMultiGraph(Graph graph)
        {

            foreach (Edge e1 in graph.Edges)
            {
                if (e1.Head == e1.Tail)
                {
                    graph.MultiGraph = true;
                    return;
                }
                foreach (Edge e2 in graph.Edges)
                {
                    if (e1.Id != e2.Id 
                        && (e1.Head == e2.Head && e1.Tail == e2.Tail
                            || (!graph.Directed && e1.Tail == e2.Head && e1.Head == e2.Tail)))
                    {
                        graph.MultiGraph = true;
                        return;
                    }
                }
            }
            graph.MultiGraph = false;
        }

        public IEnumerable<Edge> MultiGraphEdges(IEnumerable<Edge> edges, Node head, Node tail, bool directed)
        {
            IList<Edge> MultiEdges = new List<Edge>();
            if (directed)
            {
                foreach (Edge edge in edges)
                {
                    if (edge.Head == head && edge.Tail == tail) MultiEdges.Add(edge);
                }
            }
            else
            {
                foreach (Edge edge in edges)
                {
                    if (edge.Head == head && edge.Tail == tail
                        || (edge.Head == tail && edge.Tail == head)) MultiEdges.Add(edge);
                }
            }
            return MultiEdges;
        }

        public int NextId(IList<Edge> edges)
        {
            if (edges.Any())
            {
                return edges.Max(n => n.Id) + 1;
            }
            return 0;
        }
    }
}
