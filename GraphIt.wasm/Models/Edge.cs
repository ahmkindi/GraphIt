using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphIt.wasm.Models
{
    public class Edge : GraphObject, IEquatable<Edge>
    {

        public Edge(Edge edge, DefaultOptions d)
        {
            Id = edge.Id;
            Head = edge.Head;
            Tail = edge.Tail;
            Curve = edge.Curve;
            Weight = edge.Weight;
            Label = edge.Label;
            Size = edge.Size;
            LabelColor = d.EdgeLabelColor;
            Color = d.EdgeColor;
        }

        public Edge(Edge edge, DefaultOptions d, string label)
        {
            Id = edge.Id;
            Head = edge.Head;
            Tail = edge.Tail;
            Curve = edge.Curve;
            Weight = edge.Weight;
            Label = label;
            Size = edge.Size;
            LabelColor = d.EdgeLabelColor;
            Color = d.EdgeColor;
        }

        public Edge(Edge edge)
        {
            Id = edge.Id;
            Head = edge.Head;
            Tail = edge.Tail;
            Curve = edge.Curve;
            Weight = edge.Weight;
            Label = edge.Label;
            Size = edge.Size;
            LabelColor = edge.LabelColor;
            Color = edge.Color;
        }

        public Edge()
        {

        }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public double Curve { get; set; }
        public double Weight { get; set; } = 1;

        public bool Equals(Edge other)
        {
            if (this.Id == other.Id) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge);
        }

        public static bool operator ==(Edge a, Edge b)
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

        public static bool operator !=(Edge a, Edge b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
