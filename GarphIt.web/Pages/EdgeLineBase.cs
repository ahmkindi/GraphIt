using GraphIt.models;
using GraphIt.web.models;
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
        public ShowEdge ShowEdge { get; set; }
        protected override void OnParametersSet()
        {
            ShowEdge = new ShowEdge(Edge);
            ActiveEdgeCss = "";
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
