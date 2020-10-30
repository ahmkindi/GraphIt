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
        public double[] Coordinates { get; set; } = new double[6];
        public string ActiveEdgeCss { get; set; }
        protected override void OnParametersSet()
        {
            ActiveEdgeCss = "";
            if (ActiveEdge != null && ActiveEdge.EdgeId == Edge.EdgeId)
            {
                Edge = ActiveEdge;
                ActiveEdgeCss = "activeEdge";
            }
            Coordinates[0] = Edge.HeadNode.Xaxis;
            Coordinates[1] = Edge.HeadNode.Yaxis;
            Coordinates[4] = Edge.TailNode.Xaxis;
            Coordinates[5] = Edge.TailNode.Yaxis;
            if (ActiveNode != null)
            {
                if (Edge.HeadNodeId == ActiveNode.NodeId)
                {
                    Coordinates[0] = ActiveNode.Xaxis;
                    Coordinates[1] = ActiveNode.Yaxis;
                }
                else if (Edge.TailNodeId == ActiveNode.NodeId)
                {
                    Coordinates[4] = ActiveNode.Xaxis;
                    Coordinates[5] = ActiveNode.Yaxis;
                }
            }
            Coordinates[2] = ((Coordinates[0] + Coordinates[4]) / 2) + ((Math.Abs(Coordinates[1] - Coordinates[5])) * Edge.Curve);
            Coordinates[3] = ((Coordinates[1] + Coordinates[5]) / 2)+((Math.Abs(Coordinates[0] - Coordinates[4])) * Edge.Curve);
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
