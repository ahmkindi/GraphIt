using BlazorPro.BlazorSize;
using GraphIt.models;
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
        [Parameter] public DefaultDesign DefaultDesign { get; set; }
        [Parameter] public GraphType GraphType { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public EventCallback<Edge> ActiveEdgeChanged { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public ResizeListener Listener { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public string SvgClass { get; set; }
        public NewEdge NewEdge { get; set; } = new NewEdge();
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
        public List<MenuItem> NodeMenuItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"},
            new MenuItem{Text="Insert Edge"}
        };
        public List<MenuItem> CanvasMenuItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Insert Node"},
            new MenuItem{Text="Zoom In"},
            new MenuItem{Text="Zoom Out"}
        };
        public List<MenuItem> EdgeMenuItems { get; set; } = new List<MenuItem>
        {
            new MenuItem{Text="Edit"},
            new MenuItem{Text="Delete"}
        };
        public ElementReference svgCanvas;
        public SfContextMenu<MenuItem> NodeContextMenu;
        public SfContextMenu<MenuItem> CanvasContextMenu;
        public SfContextMenu<MenuItem> EdgeContextMenu;
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
            if (e.Item.Text == "Delete")
            {
                await OnDelete();
            } 
            else if (e.Item.Text == "Edit")
            {
                await ChangeMenu.InvokeAsync(NavChoice.Design);
            }
            else if (e.Item.Text == "Insert Edge")
            {
                InsertEdge();
            }
            else if (e.Item.Text == "Insert Node")
            {
                await InsertNode(origin[0], origin[1]);
            }
            else if (e.Item.Text == "Zoom In")
            {
                ZoomIn();
            }
            else if (e.Item.Text == "Zoom Out")
            {
                ZoomOut();
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
            await JSRuntime.InvokeAsync<string>("console.log", e.DeltaY);
            if (e.DeltaY > 0)
            {
                ZoomOut();
            }
            else if (e.DeltaY < 0)
            {
                ZoomIn();
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
                    NodeContextMenu.Open(e.ClientX, e.ClientY);
                    ObjectClicked.NodeRight = false;
                }
                else if (ActiveEdge != null && ObjectClicked.EdgeRight)
                {
                    EdgeContextMenu.Open(e.ClientX, e.ClientY);
                    ObjectClicked.EdgeRight = false;
                }
                else
                {
                    ActiveEdge = null;
                    ActiveNode = null;
                    CanvasContextMenu.Open(e.ClientX, e.ClientY);
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
                if (GraphType.Weighted == true)
                {
                    NewEdge.GetEdgeWeight = true;
                }
                else
                {
                    await AddNewEdge(true);
                }
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
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultDesign.EdgeLabelColor,
                    EdgeColor = DefaultDesign.EdgeColor,
                    HeadNodeId = NewEdge.Head.NodeId,
                    TailNodeId = NewEdge.Tail.NodeId,
                    Width = DefaultDesign.EdgeWidth
                };
                if (GraphType.Weighted)
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
                LabelColor = DefaultDesign.NodeLabelColor,
                NodeColor = DefaultDesign.NodeColor,
                Xaxis = x * SVGControl.Scale + SVGControl.Xaxis,
                Yaxis = y * SVGControl.Scale + SVGControl.Yaxis,
                Radius = DefaultDesign.NodeRadius
            };
            await NodeService.AddNode(newNode);
            Nodes = await NodeService.GetNodes();
        }

        public void ZoomIn()
        {
            if (SVGControl.Scale > 0.2)
            {
                SVGControl.Scale -= 0.1;
            }
        }

        public void ZoomOut()
        {
            SVGControl.Scale += 0.1;
        }
    }
}
