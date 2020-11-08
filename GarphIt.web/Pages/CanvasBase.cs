using BlazorPro.BlazorSize;
using GraphIt.models;
using GraphIt.web.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
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
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public EventCallback<IList<Edge>> ActiveEdgesChanged { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public IList<Edge> ActiveEdges { get; set; }
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
        public ObjectClicked ObjectClicked { get; set; } = new ObjectClicked();
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
            if (GraphMode == GraphMode.Default)
            {
                SvgClass = "grab";
            }
            else if (GraphMode == GraphMode.InsertNode)
            {
                SvgClass = "insert";
            }
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
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
                    if (ActiveNodes.Any()) await ChangeMenu.InvokeAsync(NavChoice.Node);
                    else await ChangeMenu.InvokeAsync(NavChoice.Edge);
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
            if (ActiveNodes.Count == 1)
            {
                NewEdge.Tail = ActiveNodes.ElementAt(0);
                NewEdge.WaitingForNode = true;
                SvgClass = "ClickNext";
            }
        }
        public async Task OnDelete()
        {
            foreach (Node node in ActiveNodes)
            {
                await NodeService.DeleteNode(node.NodeId);
            }
            foreach (Edge edge in ActiveEdges)
            {
                try
                {
                    await EdgeService.DeleteEdge(edge.EdgeId);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
            await ActiveNodesChanged.InvokeAsync(new List<Node>());
            await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
        }

        public void OnRightClick()
        {
            return;
        }
  
        public async Task OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == 2 && !e.CtrlKey)
            {
                if ((ActiveEdges.Count + ActiveNodes.Count > 1 && (ObjectClicked.NodeRight || ObjectClicked.EdgeRight)) 
                    || (ActiveEdges.Count == 1 && ObjectClicked.EdgeRight))
                {
                    ObjectClicked.NodeRight = false;
                    ObjectClicked.EdgeRight = false;
                    ContextMenus.EdgeMenu.Open(e.ClientX, e.ClientY);
                }
                else if (ActiveNodes.Count == 1 && ObjectClicked.NodeRight)
                {
                    ObjectClicked.NodeRight = false;
                    ContextMenus.NodeMenu.Open(e.ClientX, e.ClientY);
                }
                else
                {
                    ContextMenus.CanvasMenu.Open(e.ClientX, e.ClientY);
                    origin[0] = e.ClientX;
                    origin[1] = e.ClientY;
                    await ActiveNodesChanged.InvokeAsync(new List<Node>());
                    await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
                }
                return;
            }
            if (ObjectClicked.Any)
            {
                ObjectClicked.Any = false;
                if (GraphMode == GraphMode.InsertNode) SvgClass = "pointer";
                else SvgClass = "grab";
            }
            else if (!e.CtrlKey && !ActiveNodes.Any() && !ActiveEdges.Any() && GraphMode == GraphMode.InsertNode)
            {
                await InsertNode(e.ClientX, e.ClientY);
            }
            else
            {
                await ActiveNodesChanged.InvokeAsync(new List<Node>());
                await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            }
            if (SVGControl.Pan)
            {
                SVGControl.Pan = false;
                SVGControl.OldXaxis = SVGControl.Xaxis;
                SVGControl.OldYaxis = SVGControl.Yaxis;
            }
            foreach (Node node in ActiveNodes) await NodeService.UpdateNode(node);
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            origin[0] = e.ClientX;
            origin[1] = e.ClientY;
            if (!ObjectClicked.Any && e.Button != 2 && GraphMode != GraphMode.InsertNode)
            {
                SVGControl.Pan = true;
                SvgClass = "grabbing";
            }
        }
        public void OnMove(MouseEventArgs e)
        {
            if (ObjectClicked.Any && ActiveNodes.Any())
            {
                Node oldNode;
                SvgClass = "moveNode";
                foreach (Node node in ActiveNodes)
                {
                    oldNode = Nodes.First(n => n.NodeId == node.NodeId);
                    node.Xaxis = (e.ClientX - origin[0]) * SVGControl.Scale + oldNode.Xaxis;
                    node.Yaxis = (e.ClientY - origin[1]) * SVGControl.Scale + oldNode.Yaxis;
                }
            }
            else if (SVGControl.Pan)
            {
                SVGControl.Xaxis = SVGControl.OldXaxis - ((e.ClientX - origin[0]) * SVGControl.Scale);
                SVGControl.Yaxis = SVGControl.OldYaxis - ((e.ClientY - origin[1]) * SVGControl.Scale);
            }
        }
        public async Task OnEdgeClick(Edge edge)
        {
            ActiveEdges.Clear();
            ActiveEdges.Add(edge);
            await ActiveNodesChanged.InvokeAsync(new List<Node>());
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task AddActiveEdge(Edge edge)
        {
            ActiveEdges.Add(edge);
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task RemoveActiveEdge(Edge edge)
        {
            ActiveEdges.Remove(edge);
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task OnEdgeRightClick(Edge edge)
        {
            if (!(ActiveEdges.Count + ActiveNodes.Count > 1 
                && ActiveEdges.Where(e => e.EdgeId == edge.EdgeId).Any()))
            {
                ActiveEdges.Clear();
                ActiveEdges.Add(edge);
                await ActiveNodesChanged.InvokeAsync(new List<Node>());
                await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
            }
        }
        public async Task OnNodeClick(Node node)
        {
            ActiveNodes.Clear();
            ActiveNodes.Add(node);
            await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            if (NewEdge.WaitingForNode)
            {
                if (!(!DefaultOptions.MultiGraph && NewEdge.Tail.NodeId == ActiveNodes.ElementAt(0).NodeId))
                {
                    NewEdge.WaitingForNode = false;
                    NewEdge.Head = ActiveNodes.ElementAt(0);
                    if (DefaultOptions.Weighted == true)
                    {
                        NewEdge.GetEdgeWeight = true;
                    }
                    else
                    {
                        await AddNewEdge(true);
                    }
                }
            }
            else if (GraphMode == GraphMode.InsertEdge)
            {
                InsertEdge();
            }
        }

        public async Task AddActiveNode(Node node)
        {
            ActiveNodes.Add(node);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task RemoveActiveNode(Node node)
        {
            ActiveNodes.Remove(node);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnNodeRightClick(Node node)
        {
            if (!(ActiveEdges.Count + ActiveNodes.Count > 1 
                && ActiveNodes.Where(n => n.NodeId == node.NodeId).Any()))
            {
                ActiveNodes.Clear();
                ActiveNodes.Add(node);
                await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
                await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            }
        }

        public async Task AddNewEdge(bool done)
        {
            if (done && NewEdge.Head != null && NewEdge.Tail != null)
            {
                if (!DefaultOptions.MultiGraph)
                {
                    IEnumerable<Edge> edgesToDelete = await EdgeService.Search(NewEdge.Head.NodeId, NewEdge.Tail.NodeId, DefaultOptions.Directed);
                    foreach (Edge e in edgesToDelete)
                    {
                        await EdgeService.DeleteEdge(e.EdgeId);
                    }
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
                    newEdge.Weight = Math.Round(NewEdge.Weight, 2);
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
                Radius = DefaultOptions.NodeRadius,
                Label = (Nodes.Count() + 1).ToString()
            };
            await NodeService.AddNode(newNode);
            Nodes = await NodeService.GetNodes();
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
