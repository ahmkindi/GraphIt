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

        public ShowEdge(Edge edge)
        {
            EdgeArrow = new EdgeArrow();
            EdgeArrow.ArrowOffset[0] = EdgeArrow.Width;
            FontSize = 15 + (edge.Width * 1.5);
            Yoffset = 10 + edge.Width * 2;
            Rotate = 0;
            Label = edge.Label;
            Weight = edge.Weight.ToString();
            var theta = Math.Atan2(edge.HeadNode.Yaxis - edge.TailNode.Yaxis, edge.HeadNode.Xaxis - edge.TailNode.Xaxis) - Math.PI / 2;
            CurvePoint[0] = ((edge.HeadNode.Xaxis + edge.TailNode.Xaxis) / 2) + (250 * edge.Curve) * Math.Cos(theta);
            CurvePoint[1] = ((edge.HeadNode.Yaxis + edge.TailNode.Yaxis) / 2) + (250 * edge.Curve) * Math.Sin(theta);
            if (edge.HeadNode.Xaxis < edge.TailNode.Xaxis)
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
                EdgeArrow.ArrowOffset[0] += Convert.ToDouble(edge.HeadNode.Radius) / edge.Width;
                Path = $"M {edge.TailNode.Xaxis} {edge.TailNode.Yaxis} " +
                    $"Q {CurvePoint[0]} {CurvePoint[1]} {edge.HeadNode.Xaxis} {edge.HeadNode.Yaxis}";
            }
            else
            {
                Path = $"M {edge.HeadNode.Xaxis} {edge.HeadNode.Yaxis + edge.HeadNode.Radius} " +
                    $"A {edge.HeadNode.Radius} {edge.HeadNode.Radius} 0 1 0 {edge.HeadNode.Xaxis + edge.HeadNode.Radius} {edge.HeadNode.Yaxis}";
            }
        }
    }
}