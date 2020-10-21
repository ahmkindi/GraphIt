using BlazorPro.BlazorSize;
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
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class CanvasBase : ComponentBase, IDisposable
    {
        [Parameter] public DefaultDesign DefaultDesign { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeDesign { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public bool InsertNode { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public ResizeListener Listener { get; set; }
        public string SvgClass { get; set; }
        public Node MovingNode { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public IEnumerable<Node> Nodes { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"},
            new MenuItem{Text="Insert Edge"}
        };
        public ElementReference svgCanvas;
        public SfContextMenu<MenuItem> ContextMenu;
        private bool pan = false;
        public ViewBox ViewBox { get; set; } = new ViewBox();
        public double Scale { get; set; } = 1;
        private double[] oldViewBox = {0, 0};
        private double[] origin = new double[2];

        protected override async Task OnInitializedAsync()
        {
            Nodes = await NodeService.GetNodes();
            ViewBox.Xaxis = oldViewBox[0];
            ViewBox.Yaxis = oldViewBox[1];
        }
        protected override async Task OnParametersSetAsync()
        {
            if (ActiveNode != null)
            {
                await NodeService.UpdateNode(ActiveNode);
            }
            if (InsertNode)
            {
                SvgClass = "insert";
            }
            else
            {
                SvgClass = "grab";
            }
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("SetFocusToElement", svgCanvas);
                Listener.OnResized += WindowResized;
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

        public async Task OnScroll(WheelEventArgs e)
        {
            await JSRuntime.InvokeAsync<string>("console.log", e.DeltaY);
            if (e.DeltaY > 0)
            {
                Scale += 0.1;
            }
            else if (e.DeltaY < 0)
            {
                Scale -= 0.1;
            }
        }

        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            if (ActiveNode != null && MovingNode == null && (e.Key == "Delete" || e.Key == "Backspace"))
            {
                await JSRuntime.InvokeAsync<string>("console.log", e.Key);
                await OnMenuDelete();
            }   
        }

        public void OnRightClick()
        {
            return;
        }
        // TODO: Use node id in label
        // TODO: Only show weight if not all one
        // TODO: Useful footer similar to word
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
                Math.Abs(e.ClientX*Scale+ViewBox.Xaxis-ActiveNode.Xaxis) <= ActiveNode.Radius
                && Math.Abs(e.ClientY*Scale+ViewBox.Yaxis-ActiveNode.Yaxis) <= ActiveNode.Radius)
            {
                ContextMenu.Open(e.ClientX, e.ClientY);
            }
            else if (ActiveNode == null)
            {
                if (InsertNode)
                {
                    Node newNode = new Node
                    {
                        LabelColor = DefaultDesign.NodeLabelColor,
                        NodeColor = DefaultDesign.NodeColor,
                        Xaxis = e.ClientX * Scale + ViewBox.Xaxis,
                        Yaxis = e.ClientY * Scale + ViewBox.Yaxis,
                        Radius = DefaultDesign.NodeRadius
                    };
                    await NodeService.AddNode(newNode);
                }
                else if (pan)
                {
                    oldViewBox[0] = ViewBox.Xaxis;
                    oldViewBox[1] = ViewBox.Yaxis;
                }
            }
            else if (MovingNode == null && ActiveNode != null)
            {
                ActiveNode = null;
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            MovingNode = null;
            if (!InsertNode)
            {
                SvgClass = "grab";
                pan = false;
            }
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

        public void OnMouseDown(MouseEventArgs e)
        {
            if (MovingNode == null && !InsertNode)
            {
                pan = true;
                SvgClass = "grabbing";
                origin[0] = e.ClientX;
                origin[1] = e.ClientY;
            }
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
                ActiveNode.Xaxis = e.ClientX * Scale + ViewBox.Xaxis;
                ActiveNode.Yaxis = e.ClientY * Scale + ViewBox.Yaxis;
            }
            else if (pan)
            {
                ViewBox.Xaxis = oldViewBox[0] - ((e.ClientX - origin[0]) * Scale);
                ViewBox.Yaxis = oldViewBox[1] - ((e.ClientY - origin[1]) * Scale);
            }
        }

        public void Dispose()
        {
            Listener.OnResized -= WindowResized;
        }

        public void WindowResized(object _, BrowserWindowSize window)
        {
            Browser = window;
            StateHasChanged();
        }
    }
}
