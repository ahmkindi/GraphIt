using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.models
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
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public ShowEdge(Edge edge, Node head, Node tail)
        {
            EdgeArrow = new EdgeArrow();
            EdgeArrow.ArrowOffset[0] = edge.Width;
            FontSize = 15 + (edge.Width * 1.5);
            Yoffset = 10 + edge.Width * 2;
            Rotate = 0;
            Label = edge.Label;
            Weight = edge.Weight.ToString();
            Head = head;
            Tail = tail;
            var theta = Math.Atan2(Head.Yaxis - Tail.Yaxis, Head.Xaxis - Tail.Xaxis) - Math.PI / 2;
            CurvePoint[0] = ((Head.Xaxis + Tail.Xaxis) / 2) + (250 * edge.Curve) * Math.Cos(theta);
            CurvePoint[1] = ((Head.Yaxis + Tail.Yaxis) / 2) + (250 * edge.Curve) * Math.Sin(theta);
            if (Head.Xaxis < Tail.Xaxis)
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
            if (edge.HeadNodeId != edge.TailNodeId)
            {
                EdgeArrow.ArrowOffset[0] += Convert.ToDouble(Head.Radius) / edge.Width;
                Path = $"M {Tail.Xaxis} {Tail.Yaxis} Q {CurvePoint[0]} {CurvePoint[1]} {Head.Xaxis} {Head.Yaxis}";
            }
            else
            {
                Path = $"M {Head.Xaxis} {Head.Yaxis + Head.Radius} " +
                    $"A {Head.Radius} {Head.Radius} 0 1 0 {Head.Xaxis + Head.Radius} {Head.Yaxis}";
            }
        }
    }
}