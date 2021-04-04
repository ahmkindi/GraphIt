using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphIt.wasm.Models
{
    public class Node : GraphObject, IEquatable<Node>
    {
        public double Xaxis { get; set; }
        public double Yaxis { get; set; }
        public string Header { get; set; }

        public Node()
        {
        }
        public Node(int id, double x, double y)
        {
            Id = id;
            Xaxis = x;
            Yaxis = y;
        }

        public Node(Node node, DefaultOptions d)
        {
            Id = node.Id;
            Size = node.Size;
            Xaxis = node.Xaxis;
            Yaxis = node.Yaxis;
            Label = node.Label;
            Color = d.NodeColor;
            LabelColor = d.NodeLabelColor;
        }

        public Node(Node node)
        {
            Id = node.Id;
            Size = node.Size;
            Xaxis = node.Xaxis;
            Yaxis = node.Yaxis;
            Label = node.Label;
            Color = node.Color;
            LabelColor = node.LabelColor;
            Header = node.Header;
        }

        public Node(Node node, DefaultOptions d, string h)
        {
            Id = node.Id;
            Size = node.Size;
            Xaxis = node.Xaxis;
            Yaxis = node.Yaxis;
            Label = node.Label;
            Color = d.NodeColor;
            LabelColor = d.NodeLabelColor;
            Header = h;
        }

        public bool Equals(Node other)
        {
            if (this.Id == other.Id) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Node);
        }

        public static bool operator ==(Node a, Node b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Node a, Node b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
