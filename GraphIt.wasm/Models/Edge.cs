using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphIt.wasm.Models
{
    public class Edge : IEquatable<Edge>
    {

        public Edge(Edge edge, DefaultOptions d)
        {
            EdgeId = edge.EdgeId;
            HeadNodeId = edge.HeadNodeId;
            TailNodeId = edge.TailNodeId;
            Curve = edge.Curve;
            Weight = edge.Weight;
            Label = edge.Label;
            Width = edge.Width;
            LabelColor = d.EdgeLabelColor;
            EdgeColor = d.EdgeColor;
        }
        public Edge()
        {

        }
        public int EdgeId { get; set; }
        public int HeadNodeId { get; set; }
        public int TailNodeId { get; set; }
        public double Curve { get; set; }
        public double Weight { get; set; } = 1;
        public string Label { get; set; }
        public int Width { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string EdgeColor { get; set; }

        public bool Equals(Edge other)
        {
            if (this.EdgeId == other.EdgeId) return true;
            return false;
        }

        public Node HeadNode(IEnumerable<Node> nodes)
        {
            foreach (Node n in nodes)
            {
                if (n.NodeId == HeadNodeId) return n;
            }
            return null;
        }

        public Node TailNode(IEnumerable<Node> nodes)
        {
            foreach (Node n in nodes)
            {
                if (n.NodeId == TailNodeId) return n;
            }
            return null;
        }
    }
}
