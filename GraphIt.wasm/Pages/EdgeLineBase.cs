using GraphIt.wasm.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages
{
    public class EdgeLineBase : ComponentBase
    {
        [Parameter] public Edge Edge { get; set; }
        [Parameter] public ObjectClicked ObjectClicked { get; set; }
        [Parameter] public EventCallback<ObjectClicked> ObjectClickedChanged { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeClick { get; set; }
        [Parameter] public EventCallback<Edge> AddActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> RemoveActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> OnEdgeRightClick { get; set; }
        [Parameter] public bool Active { get; set; }
        [Parameter] public bool Weighted { get; set; }
        [Parameter] public bool Directed { get; set; }
        public string ActiveEdgeCss { get; set; }
        public ShowEdge ShowEdge { get; set; }
        protected override void OnParametersSet()
        {
            ShowEdge = null;
            ActiveEdgeCss = "";
            if (Active) ActiveEdgeCss = "activeEdge";
            foreach (Node node in ActiveNodes)
            {
                if (Edge.Head == node)
                {
                    ShowEdge = new ShowEdge(Edge, node, Edge.Tail);
                }
                else if (Edge.Tail == node)
                {
                    ShowEdge = new ShowEdge(Edge, Edge.Head, node);
                }
            }
            if (ShowEdge == null) ShowEdge = new ShowEdge(Edge);
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
