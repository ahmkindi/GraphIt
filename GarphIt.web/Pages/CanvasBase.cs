using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.HeatMap;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.SplitButtons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class CanvasBase : ComponentBase
    {
        [Parameter]
        public DefaultDesign DefaultDesign { get; set; }
        [Parameter]
        public EventCallback<Node> ActiveNodeDesign { get; set; }
        [Parameter]
        public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter]
        public EventCallback<NavChoice?> ChangeMenu { get; set; }
        public IEnumerable<Node> Nodes { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"},
            new MenuItem{Text="Insert Edge"}
        };
        [Parameter]
        public Node ActiveNode { get; set; }
        public ElementReference svgCanvas;
        public SfContextMenu<MenuItem> ContextMenu;
        private bool moved = false;

        [Inject]
        public INodeService NodeService { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        public Node MovingNode { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Nodes = await NodeService.GetNodes();
        }
        protected override async Task OnParametersSetAsync()
        {
            if (ActiveNode != null)
            {
                await NodeService.UpdateNode(ActiveNode);
            }
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("SetFocusToElement", svgCanvas);
            }
        }

        public async Task Select(MenuEventArgs<MenuItem> e)
        {
            if (e.Item.Text == "Delete")
            {
                await OnMenuDelete();
            } 
            else if (e.Item.Text == "Edit")
            {
                await OnMenuEdit();
            }
        }

        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            if (ActiveNode != null && (e.Key == "Delete" || e.Key == "Backspace"))
            {
                await JSRuntime.InvokeAsync<string>("console.log", e.Key);
                await OnMenuDelete();
            }   
        }

        public void OnRightClick()
        {
            return;
        }

        public async Task OnMouseUp(MouseEventArgs e)
        {
            if (MovingNode != null)
            {
                if (ActiveNode == null || ActiveNode.NodeId != MovingNode.NodeId)
                {
                    ActiveNode = MovingNode;
                }
                else
                {
                    await NodeService.UpdateNode(ActiveNode);
                }
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            if (ActiveNode != null && e.Button == 2 && 
                Math.Abs(e.ClientX-ActiveNode.Xaxis) <= ActiveNode.Radius
                && Math.Abs(e.ClientY-ActiveNode.Yaxis) <= ActiveNode.Radius)
            {
                ContextMenu.Open(e.ClientX, e.ClientY);
            }
            else if (ActiveNode == null)
            {
                Node newNode = new Node
                {
                    LabelColor = DefaultDesign.NodeLabelColor,
                    NodeColor = DefaultDesign.NodeColor,
                    Xaxis = e.ClientX,
                    Yaxis = e.ClientY,
                    Radius = DefaultDesign.NodeRadius
                };
                await NodeService.AddNode(newNode);
            }
            else if (MovingNode == null && ActiveNode != null)
            {
                ActiveNode = null;
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            MovingNode = null;
            Nodes = await NodeService.GetNodes();
        }
        public async Task OnNodeMouseDown(Node node)
        {
            MovingNode = node;
            if (ActiveNode != null)
            {
                await NodeService.UpdateNode(ActiveNode);
            }
        }
        public async Task OnMenuDelete()
        {
            await NodeService.DeleteNode(ActiveNode.NodeId);
            Nodes = await NodeService.GetNodes();
            ActiveNode = null;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
        }

        public async Task OnMenuEdit()
        {
            await ChangeMenu.InvokeAsync(NavChoice.Design);
        }

        public async Task OnMove(MouseEventArgs e)
        {
            if (MovingNode != null)
            {
                if (ActiveNode == null || ActiveNode.NodeId != MovingNode.NodeId) 
                {
                    ActiveNode = MovingNode;
                    await ActiveNodeChanged.InvokeAsync(ActiveNode);
                }
                ActiveNode.Xaxis = e.ClientX;
                ActiveNode.Yaxis = e.ClientY;
            }
        }
    }
}
