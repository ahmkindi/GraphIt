using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.SplitButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class NodeCircleBase : ComponentBase
    {
        [Parameter] public EventCallback<Node> OnNodeClick { get; set; }
        [Parameter] public EventCallback<Node> OnNodeRightClick { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Node Node { get; set; }
        public string NodeCss { get; set; }

        protected override void OnInitialized()
        {
            NodeCss = "pointer";
        }

        protected override void OnParametersSet()
        {
            if (ActiveNode != null && ActiveNode.NodeId == Node.NodeId)
            {
                Node = ActiveNode;
            }
        }
        public async Task OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                await OnNodeRightClick.InvokeAsync(Node);
            }
            else
            {
                NodeCss = "moveNode";
                await OnNodeClick.InvokeAsync(Node);
            }   
        }

        public void OnMouseUp()
        {
            NodeCss = "pointer";
        }
    }
}
