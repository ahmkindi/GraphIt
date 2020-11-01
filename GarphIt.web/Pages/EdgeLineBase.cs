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
        public double[] CurvePoint { get; set; } = new double[2];
        protected override void OnParametersSet()
        {
            ActiveEdgeCss = "";
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
                ArrowOffset = 0;
            }
            else
            {
                ArrowOffset = Convert.ToDouble(-Edge.HeadNode.Radius) / Edge.Width;
            }
            CurvePoint[0] = ((Edge.HeadNode.Xaxis + Edge.TailNode.Xaxis) / 2) + ((Math.Abs(Edge.HeadNode.Yaxis - Edge.TailNode.Yaxis)) * Edge.Curve);
            CurvePoint[1] = ((Edge.HeadNode.Yaxis + Edge.TailNode.Yaxis) / 2) + ((Math.Abs(Edge.HeadNode.Xaxis - Edge.TailNode.Xaxis)) * Edge.Curve);
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
