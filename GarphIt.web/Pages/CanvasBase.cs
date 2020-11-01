using BlazorPro.BlazorSize;
using GraphIt.models;
using GraphIt.web.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Charts;
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
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public EventCallback<Edge> ActiveEdgeChanged { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Parameter] public double Scale { get; set; }
        [Parameter] public EventCallback<double> ScaleChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public ResizeListener Listener { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public string SvgClass { get; set; }
        public NewEdge NewEdge { get; set; } = new NewEdge();
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
        public ElementReference svgCanvas;
        public ContextMenus ContextMenus { get; set; } = new ContextMenus();
        private ObjectClicked ObjectClicked = new ObjectClicked();
        public SVGControl SVGControl { get; set; } = new SVGControl();
        private double[] origin = new double[2];
        protected override async Task OnInitializedAsync()
        {
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
        }
        protected override async Task OnParametersSetAsync()
        {
            SVGControl.Scale = Scale;
            if (ActiveNode != null)
            {
                await NodeService.UpdateNode(ActiveNode);
                Nodes = await NodeService.GetNodes();
            }
            if (ActiveEdge != null)
            {
                await EdgeService.UpdateEdge(ActiveEdge);
                Edges = await EdgeService.GetEdges();
            }
            if (GraphMode == GraphMode.Default)
            {
                SvgClass = "grab";
            }
            else if (GraphMode == GraphMode.InsertNode)
            {
                SvgClass = "insert";
            }
        }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Listener.OnResized += WindowResized;
            }
        }

        public async Task Select(MenuEventArgs<MenuItem> e)
        {
            switch (e.Item.Text)
            {
                case "Delete":
                    await OnDelete();
                    break;
                case "Edit":
                    await ChangeMenu.InvokeAsync(NavChoice.Selected);
                    break;
                case "Insert Edge":
                    InsertEdge();
                    break;
                case "Insert Node":
                    await InsertNode(origin[0], origin[1]);
                    break;
                case "Zoom In":
                    await ZoomIn();
                    break;
                case "Zoom Out":
                    await ZoomOut();
                    break;
            }
        }

        public void InsertEdge()
        {
            NewEdge.Tail = ActiveNode;
            NewEdge.WaitingForNode = true;
            SvgClass = "ClickNext";
        }
        public async Task OnDelete()
        {
            if (ActiveNode != null)
            {
                await NodeService.DeleteNode(ActiveNode.NodeId);
                Nodes = await NodeService.GetNodes();
                Edges = await EdgeService.GetEdges();
                ActiveNode = null;
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            else if (ActiveEdge != null)
            {
                await EdgeService.DeleteEdge(ActiveEdge.EdgeId);
                Edges = await EdgeService.GetEdges();
                ActiveEdge = null;
                await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            }
        }

        public async Task OnScroll(WheelEventArgs e)
        {
            if (e.DeltaY > 0)
            {
                await ZoomOut();
            }
            else if (e.DeltaY < 0)
            {
                await ZoomIn();
            }
        }

        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            if (e.Key == "Delete" || e.Key == "Backspace")
            {
                await OnDelete();
            }
        }

        public void OnRightClick()
        {
            return;
        }
  
        public async Task OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                if (ActiveNode != null && ObjectClicked.NodeRight)
                {
                    ContextMenus.NodeMenu.Open(e.ClientX, e.ClientY);
                    ObjectClicked.NodeRight = false;
                }
                else if (ActiveEdge != null && ObjectClicked.EdgeRight)
                {
                    ContextMenus.EdgeMenu.Open(e.ClientX, e.ClientY);
                    ObjectClicked.EdgeRight = false;
                }
                else
                {
                    ActiveEdge = null;
                    ActiveNode = null;
                    ContextMenus.CanvasMenu.Open(e.ClientX, e.ClientY);
                    origin[0] = e.ClientX;
                    origin[1] = e.ClientY;
                    await ActiveNodeChanged.InvokeAsync(ActiveNode);
                    await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
                }
            }
            else
            {
                if (ObjectClicked.Node)
                {
                    ObjectClicked.Node = false;
                    SvgClass = "pointer";
                    await NodeService.UpdateNode(ActiveNode);
                    Nodes = await NodeService.GetNodes();
                    Edges = await EdgeService.GetEdges();
                }
                else if (ActiveNode == null)
                {
                    if (GraphMode == GraphMode.InsertNode)
                    {
                        await InsertNode(e.ClientX, e.ClientY);
                    }
                    else if (SVGControl.Pan)
                    {
                        SVGControl.OldXaxis = SVGControl.Xaxis;
                        SVGControl.OldYaxis = SVGControl.Yaxis;
                    }
                }
                else if (ActiveNode != null)
                {
                    ActiveNode = null;
                    await ActiveNodeChanged.InvokeAsync(ActiveNode);
                }
                if (ObjectClicked.Edge)
                {
                    ObjectClicked.Edge = false;
                }
                else if (ActiveEdge != null)
                {
                    ActiveEdge = null;
                    await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
                }
                if (GraphMode != GraphMode.InsertNode)
                {
                    SvgClass = "grab";
                    SVGControl.Pan = false;
                }
            }
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            if (!ObjectClicked.Node && !ObjectClicked.Edge && e.Button != 2 && GraphMode != GraphMode.InsertNode)
            {
                SVGControl.Pan = true;
                SvgClass = "grabbing";
                origin[0] = e.ClientX;
                origin[1] = e.ClientY;
            }
        }
        public void OnMove(MouseEventArgs e)
        {
            if (ObjectClicked.Node && ActiveNode != null)
            {
                SvgClass = "moveNode";
                ActiveNode.Xaxis = e.ClientX * SVGControl.Scale + SVGControl.Xaxis;
                ActiveNode.Yaxis = e.ClientY * SVGControl.Scale + SVGControl.Yaxis;
            }
            else if (SVGControl.Pan)
            {
                SVGControl.Xaxis = SVGControl.OldXaxis - ((e.ClientX - origin[0]) * SVGControl.Scale);
                SVGControl.Yaxis = SVGControl.OldYaxis - ((e.ClientY - origin[1]) * SVGControl.Scale);
            }
        }
        public async Task OnEdgeClick(Edge edge)
        {
            ActiveNode = null;
            ActiveEdge = edge;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            ObjectClicked.Edge = true;
        }
        public async Task OnEdgeRightClick(Edge edge)
        {
            ActiveNode = null;
            ActiveEdge = edge;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            ObjectClicked.EdgeRight = true;
        }
        public async Task OnNodeClick(Node node)
        {
            ActiveNode = node;
            ActiveEdge = null;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            ObjectClicked.Node = true;
            if (NewEdge.WaitingForNode)
            {
                NewEdge.WaitingForNode = false;
                NewEdge.Head = ActiveNode;
                if (DefaultOptions.Weighted == true)
                {
                    NewEdge.GetEdgeWeight = true;
                }
                else
                {
                    await AddNewEdge(true);
                }
            }
            else if (GraphMode == GraphMode.InsertEdge)
            {
                InsertEdge();
            }
        }
        public async Task OnNodeRightClick(Node node)
        {
            ActiveNode = node;
            ActiveEdge = null;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
            ObjectClicked.NodeRight = true;
        }

        public async Task AddNewEdge(bool done)
        {
            if (done && NewEdge.Head != null && NewEdge.Tail != null)
            {
                IEnumerable<Edge> edgesToDelete = await EdgeService.Search(NewEdge.Head.NodeId, NewEdge.Tail.NodeId, DefaultOptions.Directed);
                foreach (Edge e in edgesToDelete) 
                {
                    await EdgeService.DeleteEdge(e.EdgeId);
                }
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultOptions.EdgeLabelColor,
                    EdgeColor = DefaultOptions.EdgeColor,
                    HeadNodeId = NewEdge.Head.NodeId,
                    TailNodeId = NewEdge.Tail.NodeId,
                    Width = DefaultOptions.EdgeWidth,
                    Directed = DefaultOptions.Directed
                };
                if (DefaultOptions.Weighted)
                {
                    newEdge.Weight = NewEdge.Weight;
                }
                await EdgeService.AddEdge(newEdge);
                Edges = await EdgeService.GetEdges();
            }
            NewEdge.GetEdgeWeight = false;
            Edges = await EdgeService.GetEdges();
            NewEdge = new NewEdge();
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

        public async Task InsertNode(double x, double y)
        {
            Node newNode = new Node
            {
                LabelColor = DefaultOptions.NodeLabelColor,
                NodeColor = DefaultOptions.NodeColor,
                Xaxis = x * SVGControl.Scale + SVGControl.Xaxis,
                Yaxis = y * SVGControl.Scale + SVGControl.Yaxis,
                Radius = DefaultOptions.NodeRadius
            };
            await NodeService.AddNode(newNode);
            Nodes = await NodeService.GetNodes();
        }

        public async Task ZoomIn()
        {
            if (SVGControl.Scale > 0.2)
            {
                SVGControl.Scale -= 0.1;
            }
            await ScaleChanged.InvokeAsync(SVGControl.Scale);
        }

        public async Task ZoomOut()
        {
            SVGControl.Scale += 0.1;
            await ScaleChanged.InvokeAsync(SVGControl.Scale);
        }
    }
}
