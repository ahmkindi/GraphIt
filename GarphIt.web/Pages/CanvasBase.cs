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
        public string SvgClass { get; set; }
        public double EdgeWeight { get; set; } = 1;
        private bool WaitingForTail = false;
        public Node MovingNode { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>
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
        public ElementReference svgCanvas;
        public SfContextMenu<MenuItem> ContextMenu;
        public SfContextMenu<MenuItem> CanvasContextMenu;
        private bool pan = false;
        private bool moveNode = false;
        private bool edgeJustClicked = false;
        public ViewBox ViewBox { get; set; } = new ViewBox();
        public double Scale { get; set; } = 1;
        public bool GetEdgeWeight { get; set; } = false;
        private double[] oldViewBox = {0, 0};
        private double[] origin = new double[2];
        private int[] connect = new int[2];

        protected override async Task OnInitializedAsync()
        {
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
            ViewBox.Xaxis = oldViewBox[0];
            ViewBox.Yaxis = oldViewBox[1];
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
            else if (GraphMode == GraphMode.InsertEdge)
            {
                SvgClass = "alias";
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
                await OnMenuEdit();
            }
            else if (e.Item.Text == "Insert Edge")
            {
                OnMenuInsertEdge();
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

        public void OnMenuInsertEdge()
        {
            SvgClass = "alias";
            WaitingForTail = true;
            StateHasChanged();
;       }
        public async Task OnDelete()
        {
            if (ActiveNode != null)
            {
                await NodeService.DeleteNode(ActiveNode.NodeId);
                Nodes = await NodeService.GetNodes();
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

        public async Task OnMenuEdit()
        {
            await ChangeMenu.InvokeAsync(NavChoice.Design);
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
            if ((ActiveEdge != null || (ActiveNode != null && !moveNode)) && (e.Key == "Delete" || e.Key == "Backspace"))
            {
                await OnDelete();
            }
        }

        public void OnRightClick(MouseEventArgs e)
        {
            if (ActiveNode != null && Within(e.ClientX, e.ClientY))
            {
                ContextMenu.Open(e.ClientX, e.ClientY);
            }
            else
            {
                CanvasContextMenu.Open(e.ClientX, e.ClientY);
                origin[0] = e.ClientX;
                origin[1] = e.ClientY;
            }
        }
  
        public async Task OnMouseUp(MouseEventArgs e)
        {
            if (edgeJustClicked)
            {
                edgeJustClicked = false;
            }
            else
            {
                ActiveEdge = null;
                await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            }
            if (moveNode)
            {
                await NodeService.UpdateNode(ActiveNode);
                Nodes = await NodeService.GetNodes();
                moveNode = false;
            }
            else if (ActiveNode == null)
            {
                if (GraphMode == GraphMode.InsertNode)
                {
                    await InsertNode(e.ClientX, e.ClientY);
                }
                else if (pan)
                {
                    oldViewBox[0] = ViewBox.Xaxis;
                    oldViewBox[1] = ViewBox.Yaxis;
                }
            }
            else
            {
                ActiveNode = null;
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
            }
            if (GraphMode == GraphMode.Default)
            {
                SvgClass = "grab";
                pan = false;
            }
        }

        public async Task OnMouseDown(MouseEventArgs e)
        {
            if (edgeJustClicked)
            {
                return;
            }
            if (WaitingForTail && ActiveNode != null)
            {
                connect[1] = ActiveNode.NodeId;
                if (GraphType.Weighted == true)
                {
                    GetEdgeWeight = true;
                }
                else
                {
                    await AddNewEdge(true);
                }
            }
            if (ActiveNode != null && Within(e.ClientX, e.ClientY))
            {
                ActiveEdge = null;
                await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
                await ActiveNodeChanged.InvokeAsync(ActiveNode);
                moveNode = true;
                if (WaitingForTail)
                {
                    WaitingForTail = false;
                }
                else
                {
                    connect[0] = ActiveNode.NodeId;
                }
            }
            else if (e.Button != 2 && GraphMode == GraphMode.Default)
            {
                pan = true;
                SvgClass = "grabbing";
                origin[0] = e.ClientX;
                origin[1] = e.ClientY;
            }
        }
        public void OnMove(MouseEventArgs e)
        {
            if (moveNode)
            {
                ActiveNode.Xaxis = e.ClientX * Scale + ViewBox.Xaxis;
                ActiveNode.Yaxis = e.ClientY * Scale + ViewBox.Yaxis;
            }
            else if (pan)
            {
                ViewBox.Xaxis = oldViewBox[0] - ((e.ClientX - origin[0]) * Scale);
                ViewBox.Yaxis = oldViewBox[1] - ((e.ClientY - origin[1]) * Scale);
            }
        }
        public async Task OnEdgeClick(Edge edge)
        {
            ActiveEdge = edge;
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
            edgeJustClicked = true;
        }
        public async Task AddNewEdge(bool done)
        {
            if (done)
            {
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultDesign.EdgeLabelColor,
                    EdgeColor = DefaultDesign.EdgeColor,
                    HeadNodeId = connect[0],
                    TailNodeId = connect[1],
                    Width = DefaultDesign.EdgeWidth
                };
                if (GraphType.Weighted)
                {
                    newEdge.Weight = EdgeWeight;
                }
                await EdgeService.AddEdge(newEdge);
                Edges = await EdgeService.GetEdges();
            }
            GetEdgeWeight = false;
            Edges = await EdgeService.GetEdges();
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
        public bool Within(double x, double y)
        {
            return Math.Abs(x * Scale + ViewBox.Xaxis - ActiveNode.Xaxis) <= ActiveNode.Radius
                    && Math.Abs(y * Scale + ViewBox.Yaxis - ActiveNode.Yaxis) <= ActiveNode.Radius;
        }

        public async Task InsertNode(double x, double y)
        {
            Node newNode = new Node
            {
                LabelColor = DefaultDesign.NodeLabelColor,
                NodeColor = DefaultDesign.NodeColor,
                Xaxis = x * Scale + ViewBox.Xaxis,
                Yaxis = y * Scale + ViewBox.Yaxis,
                Radius = DefaultDesign.NodeRadius
            };
            await NodeService.AddNode(newNode);
            Nodes = await NodeService.GetNodes();
        }

        public void ZoomIn()
        {
            if (Scale > 0.2)
            {
                Scale -= 0.1;
            }
        }

        public void ZoomOut()
        {
            Scale += 0.1;
        }
    }
}
