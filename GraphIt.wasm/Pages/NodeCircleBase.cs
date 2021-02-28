using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.SplitButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages
{
    public class NodeCircleBase : ComponentBase
    {
        [Parameter] public EventCallback<Node> OnNodeClick { get; set; }
        [Parameter] public EventCallback<Node> AddActiveNode { get; set; }
        [Parameter] public EventCallback<Node> RemoveActiveNode { get; set; }
        [Parameter] public EventCallback<Node> OnNodeRightClick { get; set; }
        [Parameter] public ObjectClicked ObjectClicked { get; set; }
        [Parameter] public EventCallback<ObjectClicked> ObjectClickedChanged { get; set; }
        [Parameter] public Node Node { get; set; }
        [Parameter] public bool Active { get; set; }
        public string NodeCss { get; set; }
        protected override void OnParametersSet()
        {
            if (Active) NodeCss = "moveNode";
            else NodeCss = "pointer";
        }
        public async Task OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                ObjectClicked.Right = true;
                await ObjectClickedChanged.InvokeAsync(ObjectClicked);
                await OnNodeRightClick.InvokeAsync(Node);
            }
            else
            {
                ObjectClicked.Left = true;
                await ObjectClickedChanged.InvokeAsync(ObjectClicked);
                if (e.CtrlKey)
                {
                    if (Active) await RemoveActiveNode.InvokeAsync(Node);
                    else await AddActiveNode.InvokeAsync(Node);
                }
                else if (!Active) await OnNodeClick.InvokeAsync(Node);
            }   
        }
    }
}
