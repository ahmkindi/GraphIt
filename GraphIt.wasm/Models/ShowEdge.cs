using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class ShowEdge
    {
        public string Label { get; set; }
        public string Weight { get; set; }
        public double FontSize { get; set; }
        public int Yoffset { get; set; }
        public int Rotate { get; set; }
        public string Path { get; set; }
        public double[] CurvePoint { get; set; } = new double[2];
        public EdgeArrow EdgeArrow { get; set; }

        public ShowEdge(Edge edge) : this(edge, edge.Head, edge.Tail) { }

        public ShowEdge(Edge edge, Node head, Node tail)
        {
            EdgeArrow = new EdgeArrow();
            FontSize = 15 + (edge.Size * 1.5);
            Yoffset = 10 + edge.Size * 2;
            Rotate = 0;
            Label = edge.Label;
            Weight = edge.Weight.ToString();
            var theta = Math.Atan2(head.Yaxis - tail.Yaxis, head.Xaxis - tail.Xaxis) - Math.PI / 2;
            CurvePoint[0] = ((head.Xaxis + tail.Xaxis) / 2) + (250 * edge.Curve) * Math.Cos(theta);
            CurvePoint[1] = ((head.Yaxis + tail.Yaxis) / 2) + (250 * edge.Curve) * Math.Sin(theta);
            if (head.Xaxis < tail.Xaxis)
            {
                Rotate = 180;
                char[] temp = edge.Weight.ToString().ToCharArray();
                Array.Reverse(temp);
                Weight = new string(temp);
                if (edge.Label != null)
                {
                    temp = edge.Label.ToCharArray();
                    Array.Reverse(temp);
                    Label = new string(temp);
                }
            }
            if (head.Id != tail.Id)
            {
                EdgeArrow.ArrowOffset[0] += Convert.ToDouble(head.Size) / edge.Size;
                Path = $"M {tail.Xaxis} {tail.Yaxis} Q {CurvePoint[0]} {CurvePoint[1]} {head.Xaxis} {head.Yaxis}";
            }
            else
            {
                Path = $"M {head.Xaxis} {head.Yaxis + head.Size} " +
                    $"A {head.Size} {head.Size} 0 1 0 {head.Xaxis + head.Size} {head.Yaxis}";
            }
        }
    }
}