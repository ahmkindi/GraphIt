using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class AlgoEdgeLineBase : ComponentBase
    {
        [Parameter] public Edge Edge { get; set; }
        [Parameter] public IList<Node> Nodes { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        public ShowEdge ShowEdge { get; set; }
        protected override void OnParametersSet()
        {
            ShowEdge = null;
            ActiveEdgeCss = "";
            if (Active) ActiveEdgeCss = "activeEdge";
            foreach (Node node in ActiveNodes)
            {
                if (Edge.HeadNodeId == node.NodeId)
                {
                    ShowEdge = new ShowEdge(Edge, node, Edge.TailNode(Nodes));
                }
                else if (Edge.TailNodeId == node.NodeId)
                {
                    ShowEdge = new ShowEdge(Edge, Edge.HeadNode(Nodes), node);
                }
            }
            if (ShowEdge == null) ShowEdge = new ShowEdge(Edge, Edge.HeadNode(Nodes), Edge.TailNode(Nodes));
        }
        public async Task OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == 2 && !e.CtrlKey)
            {
                ObjectClicked.Right = true;
                await ObjectClickedChanged.InvokeAsync(ObjectClicked);
                await OnEdgeRightClick.InvokeAsync(Edge);
            }
            else
            {
                ObjectClicked.Left = true;
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
