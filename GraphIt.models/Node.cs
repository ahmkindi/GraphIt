using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphIt.models
{
    public class Node : IEquatable<Node>
    {
        public int NodeId { get; set; }
        public double Xaxis { get; set; }
        public double Yaxis { get; set; }
        public int Radius { get; set; }
        public string Label { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string NodeColor { get; set; }

        public bool Equals(Node other)
        {
            if (this.NodeId == other.NodeId) return true;
            return false;
        }
        public Node()
        {
        }
        public Node(int id, double x, double y)
        {
            NodeId = id;
            Xaxis = x;
            Yaxis = y;
        }

        public Node(Node node, DefaultOptions d)
        {
            NodeId = node.NodeId;
            Radius = node.Radius;
            Xaxis = node.Xaxis;
            Yaxis = node.Yaxis;
            Label = node.Label;
            NodeColor = d.NodeColor;
            LabelColor = d.NodeLabelColor;
        }
    }
}
