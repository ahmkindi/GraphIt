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
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public ObjectClicked ObjectClicked { get; set; }
        [Parameter] public EventCallback<ObjectClicked> ObjectClickedChanged { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeClick { get; set; }
        [Parameter] public EventCallback<Edge> AddActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> RemoveActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeRightClick { get; set; }
        [Parameter] public bool Active { get; set; }
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
            if (Active) ActiveEdgeCss = "activeEdge";
            foreach (Node node in ActiveNodes)
            {
                if (Edge.HeadNodeId == node.NodeId)
                {
                    Edge.HeadNode = node;
                }
                else if (Edge.TailNodeId == node.NodeId)
                {
                    Edge.TailNode = node;
                }
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
            if (e.Button == 2 && !e.CtrlKey)
            {
                ObjectClicked.EdgeRight = true;
                await ObjectClickedChanged.InvokeAsync(ObjectClicked);
                await OnEdgeRightClick.InvokeAsync(Edge);
            }
            else
            {
                ObjectClicked.Any = true;
                await ObjectClickedChanged.InvokeAsync(ObjectClicked);
                if (e.CtrlKey)
                {
                    if (Active) await RemoveActiveEdge.InvokeAsync(Edge);
                    else await AddActiveEdge.InvokeAsync(Edge);
                }
                else if (!Active) await OnEdgeClick.InvokeAsync(Edge);
            }
        }
    }
}
