using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class EdgeService : IEdgeService
    {
        public Edge AddEdge(IList<Edge> edges, DefaultOptions d, int head, int tail, double weight)
        {
            Edge edge = new Edge
            {
                EdgeId = NextId(edges),
                LabelColor = d.EdgeLabelColor,
                EdgeColor = d.EdgeColor,
                HeadNodeId = head,
                TailNodeId = tail,
                Width = d.EdgeWidth,
                Weight = weight
            };
            edges.Add(edge);
            return edge;
        }
        public Edge AddEdge(IList<Edge> edges, DefaultOptions d, int head, int tail)
        {
            Edge edge = new Edge
            {
                EdgeId = NextId(edges),
                LabelColor = d.EdgeLabelColor,
                EdgeColor = d.EdgeColor,
                HeadNodeId = head,
                TailNodeId = tail,
                Width = d.EdgeWidth,
            };
            edges.Add(edge);
            return edge;
        }

        public Edge AddEdge(IList<Edge> edges, Edge e)
        {
            Edge edge = new Edge
            {
                EdgeId = NextId(edges),
                LabelColor = e.LabelColor,
                EdgeColor = e.EdgeColor,
                HeadNodeId = e.HeadNodeId,
                TailNodeId = e.TailNodeId,
                Width = e.Width,
                Curve = e.Curve,
                Weight = e.Weight
            };
            edges.Add(edge);
            return edge;
        }

        public Edge AddEdge(IList<Edge> edges, Edge e, int id)
        {
            Edge edge = new Edge
            {
                EdgeId = NextId(edges),
                LabelColor = e.LabelColor,
                EdgeColor = e.EdgeColor,
                HeadNodeId = id + e.HeadNodeId,
                TailNodeId = id + e.TailNodeId,
                Width = e.Width,
                Curve = e.Curve,
                Weight = e.Weight
            };
            edges.Add(edge);
            return edge;
        }

        public void DeleteEdges(List<Edge> edges, IList<Edge> edgesToDel)
        {
            edges.RemoveAll(e => edgesToDel.Contains(e));
        }

        public void UpdateMultiGraph(DefaultOptions d, List<Edge> edges)
        {

            foreach (Edge e1 in edges)
            {
                if (e1.HeadNodeId == e1.TailNodeId)
                {
                    d.MultiGraph = true;
                    return;
                }
                foreach (Edge e2 in edges)
                {
                    if (e1.EdgeId != e2.EdgeId 
                        && (e1.HeadNodeId == e2.HeadNodeId && e1.TailNodeId == e2.TailNodeId
                            || (!d.Directed && e1.TailNodeId == e2.HeadNodeId && e1.HeadNodeId == e2.TailNodeId)))
                    {
                        d.MultiGraph = true;
                        return;
                    }
                }
            }
            d.MultiGraph = false;
        }

        public IEnumerable<Edge> MultiGraphEdges(IEnumerable<Edge> edges, int head, int tail, bool directed)
        {
            IList<Edge> MultiEdges = new List<Edge>();
            if (directed)
            {
                foreach (Edge edge in edges)
                {
                    if (edge.HeadNodeId == head && edge.TailNodeId == tail) MultiEdges.Add(edge);
                }
            }
            else
            {
                foreach (Edge edge in edges)
                {
                    if (edge.HeadNodeId == head && edge.TailNodeId == tail
                        || (edge.HeadNodeId == tail && edge.TailNodeId == head)) MultiEdges.Add(edge);
                }
            }
            return MultiEdges;
        }

        public int NextId(IList<Edge> edges)
        {
            if (edges.Any())
            {
                return edges.Max(n => n.EdgeId) + 1;
            }
            return 0;
        }
    }
}
