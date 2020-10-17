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
        private bool justClicked = false;
        [Inject]
        public INodeService NodeService { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
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
            if (ActiveNode != null)
            {
                await JSRuntime.InvokeAsync<string>("console.log", e.Key);
            }
        }

        public void OnRightClick()
        {
            return;
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (ActiveNode != null && e.Button == 2)
            {
                ContextMenu.Open(e.ClientX, e.ClientY);
            }
        }
        public async Task OnClick(MouseEventArgs e)
        {
            if (justClicked)
            {
                justClicked = false;
                return;
            }
            if (ActiveNode == null)
            {
                Offset Offset = await JSRuntime.InvokeAsync<Offset>("getCanvasOffsets", svgCanvas);
                Node newNode = new Node
                {
                    LabelColor = DefaultDesign.NodeLabelColor,
                    NodeColor = DefaultDesign.NodeColor,
                    Xaxis = e.ClientX - Offset.Left,
                    Yaxis = e.ClientY - Offset.Top,
                    Radius = DefaultDesign.NodeRadius
                };
                await NodeService.AddNode(newNode);
            }
            else
            {
                ActiveNode = null;
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            Nodes = await NodeService.GetNodes();
        }
        public async Task OnNodeClick(Node node)
        {
            ActiveNode = node;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            justClicked = true;
        }
        public async Task OnMenuDelete()
        {
            await NodeService.DeleteNode(ActiveNode.NodeId);
            Nodes = await NodeService.GetNodes();
            ActiveNode = null;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            justClicked = false;
        }

        public async Task OnMenuEdit()
        {
            await ChangeMenu.InvokeAsync(NavChoice.Design);
        }
    }
}
