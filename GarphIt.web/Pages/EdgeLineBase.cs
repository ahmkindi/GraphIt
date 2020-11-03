using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class EdgeLineBase : ComponentBase
    {
        [Parameter] public Edge Edge { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeClick { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeRightClick { get; set; }
        public string ActiveEdgeCss { get; set; }
        public double ArrowOffset { get; set; }
        public int Rotate { get; set; }
        public string ShowLabel { get; set; } = "";
        public string ShowWeight { get; set; }
        public double[] CurvePoint { get; set; } = new double[2];
        protected override void OnParametersSet()
        {
            ActiveEdgeCss = "";
            Rotate = 0;
            ShowLabel = Edge.Label;
            ShowWeight = Edge.Weight.ToString();
            if (ActiveEdge != null && ActiveEdge.EdgeId == Edge.EdgeId)
            {
                Edge = ActiveEdge;
                ActiveEdgeCss = "activeEdge";
            }
            if (ActiveNode != null)
            {
                if (Edge.HeadNodeId == ActiveNode.NodeId)
                {
                    Edge.HeadNode = ActiveNode;
                }
                else if (Edge.TailNodeId == ActiveNode.NodeId)
                {
                    Edge.TailNode = ActiveNode;
                }
            }
            if (Edge.HeadNodeId == Edge.TailNodeId)
            {
                ArrowOffset = 7;
                return;
            }
            ArrowOffset = 7 + Convert.ToDouble(Edge.HeadNode.Radius) / Edge.Width;
            var theta = Math.Atan2(Edge.HeadNode.Yaxis - Edge.TailNode.Yaxis, Edge.HeadNode.Xaxis - Edge.TailNode.Xaxis) - Math.PI / 2;
            CurvePoint[0] = ((Edge.HeadNode.Xaxis + Edge.TailNode.Xaxis) / 2) + (250 * Edge.Curve) * Math.Cos(theta);
            CurvePoint[1] = ((Edge.HeadNode.Yaxis + Edge.TailNode.Yaxis) / 2) + (250 * Edge.Curve) * Math.Sin(theta);
            if (Edge.HeadNode.Xaxis < Edge.TailNode.Xaxis)
            {
                Rotate = 180;
                char[] temp = Edge.Weight.ToString().ToCharArray();
                Array.Reverse(temp);
                ShowWeight = new string(temp);
                if (Edge.Label != null)
                {
                    temp = Edge.Label.ToCharArray();
                    Array.Reverse(temp);
                    ShowLabel = new string(temp);
                }
            }
        }
        public async Task OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                await OnEdgeRightClick.InvokeAsync(Edge);
            }
            else
            {
                await OnEdgeClick.InvokeAsync(Edge);
            }
        }
    }
}
