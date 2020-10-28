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
        [Parameter] public GraphType GraphType { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeClick { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeRightClick { get; set; }
        public double[] Coordinates { get; set; } = new double[4];
        public string ActiveEdgeCss { get; set; }
        protected override void OnParametersSet()
        {
            ActiveEdgeCss = "";
            Coordinates[0] = Edge.HeadNode.Xaxis;
            Coordinates[1] = Edge.HeadNode.Yaxis;
            Coordinates[2] = Edge.TailNode.Xaxis;
            Coordinates[3] = Edge.TailNode.Yaxis;
            if (ActiveNode != null)
            {
                if (Edge.HeadNodeId == ActiveNode.NodeId)
                {
                    Coordinates[0] = ActiveNode.Xaxis;
                    Coordinates[1] = ActiveNode.Yaxis;
                }
                else if (Edge.TailNodeId == ActiveNode.NodeId)
                {
                    Coordinates[2] = ActiveNode.Xaxis;
                    Coordinates[3] = ActiveNode.Yaxis;
                }
            }
            if (ActiveEdge != null && ActiveEdge.EdgeId == Edge.EdgeId)
            {
                ActiveEdgeCss = "activeEdge";
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
