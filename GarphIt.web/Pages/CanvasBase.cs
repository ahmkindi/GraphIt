using BlazorPro.BlazorSize;
using GraphIt.models;
using GraphIt.web.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class CanvasBase : ComponentBase
    {
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public EventCallback<IList<Edge>> ActiveEdgesChanged { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public IList<Edge> ActiveEdges { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<SVGControl> SVGControlChanged { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public EventCallback<List<Edge>> EdgesChanged { get; set; }
        [Parameter] public StartAlgorithm StartAlgorithm { get; set; }
        [Parameter] public EventCallback<StartAlgorithm> StartAlgorithmChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public IAlgorithmService AlgorithmService { get; set; }
        public string SvgClass { get; set; }
        public IList<Node> CopiedNodes { get; set; } = new List<Node>();
        public IList<Edge> CopiedEdges { get; set; } = new List<Edge>();
        public double PasteOffset { get; set; } = 0;
        private IList<Node> oldNodes { get; set; }
        public NewEdge NewEdge { get; set; } = new NewEdge();
        public SfContextMenu<MenuItem> ObjectContextMenu { get; set; }
        public SfContextMenu<MenuItem> CanvasContextMenu { get; set; }
        public ObjectClicked ObjectClicked { get; set; } = new ObjectClicked();
        private double[] origin = new double[2];
        public RectSelection RectSelection { get; set; } = new RectSelection();
        public IList<AlgorithmNode> AlgorithmNodes = new List<AlgorithmNode>();
        public IList<Edge> AlgorithmEdges = new List<Edge>();
        protected override void OnParametersSet()
        {
            if (GraphMode == GraphMode.Default)
            {
                SvgClass = "grab";
            }
            else if (GraphMode == GraphMode.InsertNode)
            {
                SvgClass = "insert";
            }
            if (StartAlgorithm.Ready && !StartAlgorithm.Done)
            {
                AlgorithmService.RunAlgorithm(DefaultOptions, StartAlgorithm, Nodes, ref AlgorithmNodes, Edges, ref AlgorithmEdges); 
            }
        }

        public async Task Select(MenuEventArgs<MenuItem> e)
        {
            switch (e.Item.Text)
            {
                case "Copy":
                    Copy();
                    break;
                case "Paste":
                    await Paste();
                    break;
                case "Left":
                case "Center":
                case "Right":
                case "Top":
                case "Middle":
                case "Bottom":
                    NodeService.Align(ActiveNodes, e.Item.Text);
                    break;
                case "Delete":
                    await OnDelete();
                    break;
                case "Edit":
                    if (ActiveNodes.Count == 1) await ChangeMenu.InvokeAsync(NavChoice.Node);
                    else if (ActiveEdges.Count == 1) await ChangeMenu.InvokeAsync(NavChoice.Edge);
                    break;
                case "Nodes":
                    await ChangeMenu.InvokeAsync(NavChoice.Node);
                    break;
                case "Edges":
                    await ChangeMenu.InvokeAsync(NavChoice.Edge);
                    break;
                case "Insert Edge":
                    InsertEdge();
                    break;
                case "Insert Node":
                    NodeService.AddNode(Nodes, DefaultOptions, origin[0]*SVGControl.Scale + SVGControl.Xaxis, origin[1]*SVGControl.Scale + SVGControl.Yaxis);
                    await NodesChanged.InvokeAsync(Nodes);
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
                NewEdge.Tail = ActiveNodes[0];
                NewEdge.WaitingForNode = true;
                SvgClass = "ClickNext";
            }
        }
        public async Task OnDelete()
        {
            EdgeService.DeleteEdges(Edges, ActiveEdges);
            await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            NodeService.DeleteNodes(Nodes, Edges, ActiveNodes);
            await ActiveNodesChanged.InvokeAsync(new List<Node>());
        }

        public void OnRightClick()
        {
            return;
        }
  
        public async Task OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == 2)
            {
                RectSelection.Create = false;
                if (!e.CtrlKey && RectSelection.Width <= 0 && RectSelection.Height <= 0)
                {
                    if (ObjectClicked.Right)
                    {
                        ObjectClicked.Right = false;
                        ObjectContextMenu.Open(e.ClientX, e.ClientY);
                    }
                    else
                    {
                        CanvasContextMenu.Open(e.ClientX, e.ClientY);
                        origin[0] = e.ClientX;
                        origin[1] = e.ClientY;
                        if (ActiveNodes.Any()) await ActiveNodesChanged.InvokeAsync(new List<Node>());
                        if (ActiveEdges.Any()) await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
                    }
                }
                else
                {
                    bool aNodesChanged = false;
                    bool aEdgesChanged = false;
                    foreach (Node node in Nodes)
                    {
                        if (node.Xaxis <= RectSelection.X + RectSelection.Width
                            && node.Xaxis >= RectSelection.X
                            && node.Yaxis <= RectSelection.Y + RectSelection.Height
                            && node.Yaxis >= RectSelection.Y)
                        {
                            if (!ActiveNodes.Contains(node))
                            {
                                ActiveNodes.Add(node);
                                aNodesChanged = true;
                            }
                        }
                        else if (ActiveNodes.Remove(node)) aNodesChanged = true;
                    }
                    foreach (Edge edge in Edges)
                    {
                        ShowEdge showEdge = new ShowEdge(edge, edge.HeadNode(Nodes), edge.TailNode(Nodes));
                        var x = 0.25 * showEdge.Head.Xaxis + 0.5 * showEdge.CurvePoint[0] + 0.25 * showEdge.Tail.Xaxis;
                        var y = 0.25 * showEdge.Head.Yaxis + 0.5 * showEdge.CurvePoint[1] + 0.25 * showEdge.Tail.Yaxis;
                        if (x <= RectSelection.X + RectSelection.Width
                            && x >= RectSelection.X
                            && y <= RectSelection.Y + RectSelection.Height
                            && y >= RectSelection.Y)
                        {
                            if (!ActiveEdges.Contains(edge))
                            {
                                ActiveEdges.Add(edge);
                                aEdgesChanged = true;
                            }
                        }
                        else if (ActiveEdges.Remove(edge)) aEdgesChanged = true;
                    }
                    if (aNodesChanged) await ActiveNodesChanged.InvokeAsync(ActiveNodes);
                    if (aEdgesChanged) await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
                }
                RectSelection = new RectSelection();
                return;
            }
            if (ObjectClicked.Left)
            {
                ObjectClicked.Left = false;
                if (GraphMode == GraphMode.InsertNode) SvgClass = "pointer";
                else SvgClass = "grab";
            }
            else if (!e.CtrlKey && !ActiveNodes.Any() && !ActiveEdges.Any() && GraphMode == GraphMode.InsertNode)
            {
                NodeService.AddNode(Nodes, DefaultOptions, e.ClientX*SVGControl.Scale+SVGControl.Xaxis, e.ClientY*SVGControl.Scale+SVGControl.Yaxis);
            }
            else
            {
                if (ActiveNodes.Any()) await ActiveNodesChanged.InvokeAsync(new List<Node>());
                if (ActiveEdges.Any()) await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            }
            if (SVGControl.Pan)
            {
                SVGControl.Pan = false;
                SvgClass = "grab";
                SVGControl.OldXaxis = SVGControl.Xaxis;
                SVGControl.OldYaxis = SVGControl.Yaxis;
            }
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            origin[0] = e.ClientX;
            origin[1] = e.ClientY;
            oldNodes = ActiveNodes.Select(n => new Node(n.NodeId, n.Xaxis, n.Yaxis)).ToList();
            if (!ObjectClicked.Left)
            {
                if (e.Button != 2 && GraphMode != GraphMode.InsertNode)
                {
                    SVGControl.Pan = true;
                    SvgClass = "grabbing";
                }
                else if (e.Button == 2)
                {
                    RectSelection.Create = true;
                    SvgClass = "pointer";
                }
            }
        }
        public async Task OnMove(MouseEventArgs e)
        {
            if (ObjectClicked.Left && ActiveNodes.Any())
            {
                Node oldNode;
                SvgClass = "moveNode";
                foreach (Node node in ActiveNodes)
                {
                    oldNode = oldNodes[oldNodes.IndexOf(node)];
                    node.Xaxis = (e.ClientX - origin[0]) * SVGControl.Scale + oldNode.Xaxis;
                    node.Yaxis = (e.ClientY - origin[1]) * SVGControl.Scale + oldNode.Yaxis;
                }
                if (ActiveNodes.Count == 1) await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            }
            else if (SVGControl.Pan)
            {
                SVGControl.Xaxis = SVGControl.OldXaxis - ((e.ClientX - origin[0]) * SVGControl.Scale);
                SVGControl.Yaxis = SVGControl.OldYaxis - ((e.ClientY - origin[1]) * SVGControl.Scale);
            }
            else if (RectSelection.Create)
            {
                RectSelection.Width = Math.Abs((e.ClientX - origin[0])) * SVGControl.Scale;
                RectSelection.Height = Math.Abs((e.ClientY - origin[1])) * SVGControl.Scale;
                if (e.ClientX > origin[0]) RectSelection.X = origin[0] * SVGControl.Scale + SVGControl.Xaxis;
                else RectSelection.X = e.ClientX * SVGControl.Scale + SVGControl.Xaxis;
                if (e.ClientY > origin[1]) RectSelection.Y = origin[1] * SVGControl.Scale + SVGControl.Yaxis;
                else RectSelection.Y = e.ClientY * SVGControl.Scale + SVGControl.Yaxis;                
            }
        }
        public async Task OnEdgeClick(Edge edge)
        {
            ActiveEdges.Clear();
            ActiveEdges.Add(edge);
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
            if (ActiveNodes.Any()) await ActiveNodesChanged.InvokeAsync(new List<Node>());
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
            if (!(ActiveEdges.Count + ActiveNodes.Count > 1 && ActiveEdges.Contains(edge)))
            {
                ActiveEdges.Clear();
                ActiveEdges.Add(edge);
                await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
                if (ActiveNodes.Any()) await ActiveNodesChanged.InvokeAsync(new List<Node>());
            }
        }
        public async Task OnNodeClick(Node node)
        {
            if (StartAlgorithm.Algorithm != Algorithm.None && StartAlgorithm.Type != AlgorithmType.NoInput)
            {
                if (StartAlgorithm.StartNode == null)
                {
                    StartAlgorithm.StartNode = node;
                    if (StartAlgorithm.Type == AlgorithmType.OneInput) StartAlgorithm.Ready = true;
                    await StartAlgorithmChanged.InvokeAsync(StartAlgorithm);
                }
                else if (StartAlgorithm.EndNode == null && StartAlgorithm.Type == AlgorithmType.TwoInput)
                {
                    StartAlgorithm.EndNode = node;
                    StartAlgorithm.Ready = true;
                    await StartAlgorithmChanged.InvokeAsync(StartAlgorithm);
                }
            }
            ActiveNodes.Clear();
            ActiveNodes.Add(node);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            if (ActiveEdges.Any()) await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            if (NewEdge.WaitingForNode)
            {
                NewEdge.WaitingForNode = false;
                NewEdge.Head = ActiveNodes[0];
                NewEdge.MultiEdges = EdgeService.MultiGraphEdges(Edges, NewEdge.Head.NodeId, NewEdge.Tail.NodeId, DefaultOptions.Directed);
                if (DefaultOptions.Weighted == true)
                {
                    NewEdge.GetEdgeWeight = true;
                }
                else if (!NewEdge.MultiEdges.Any())
                {
                    await AddNewEdge(true);
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
            if (!(ActiveEdges.Count + ActiveNodes.Count > 1 && ActiveNodes.Contains(node)))
            {
                ActiveNodes.Clear();
                ActiveNodes.Add(node);
                await ActiveNodesChanged.InvokeAsync(ActiveNodes);
                if (ActiveEdges.Any()) await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
            }
        }

        public async Task AddNewEdge(bool done)
        {
            if (done && NewEdge.Head != null && NewEdge.Tail != null)
            {
                if (NewEdge.MultiGraph == false && NewEdge.MultiEdges != null)
                {
                    foreach (Edge edge in NewEdge.MultiEdges) Edges.Remove(edge);
                }
                else
                {
                    DefaultOptions.MultiGraph = true;
                }
                if (DefaultOptions.Weighted) EdgeService.AddEdge(Edges, DefaultOptions, NewEdge.Head.NodeId, NewEdge.Tail.NodeId, Math.Round(NewEdge.Weight, 2));
                else EdgeService.AddEdge(Edges, DefaultOptions, NewEdge.Head.NodeId, NewEdge.Tail.NodeId);
            }
            NewEdge = new NewEdge();
            if (ActiveNodes.Any()) await ActiveNodesChanged.InvokeAsync(new List<Node>());
            if (ActiveEdges.Any()) await ActiveEdgesChanged.InvokeAsync(new List<Edge>());
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

        public async Task OnKeyDown(KeyboardEventArgs e)
        {

            if (e.Key == "ArrowRight")
            {
                foreach (Node node in ActiveNodes) node.Xaxis+=5*SVGControl.Scale;
            }
            else if (e.Key == "ArrowLeft")
            {
                foreach (Node node in ActiveNodes) node.Xaxis -= 5 * SVGControl.Scale;
            }
            else if (e.Key == "ArrowUp")
            {
                foreach (Node node in ActiveNodes) node.Yaxis -= 5 * SVGControl.Scale;
            }
            else if (e.Key == "ArrowDown")
            {
                foreach (Node node in ActiveNodes) node.Yaxis += 5 * SVGControl.Scale;
            }
            else if (e.CtrlKey) 
            {
                if (e.Key == "c") Copy();
                if (e.Key == "v" && CopiedNodes.Any()) await Paste();
             
            } 
        }

        public void Copy()
        {
            CopiedNodes.Clear();
            CopiedEdges.Clear();
            PasteOffset = 0;
            foreach (Node node in ActiveNodes)
            {
                NodeService.AddNode(CopiedNodes, node);
            }
            foreach (Edge edge in ActiveEdges)
            {
                if (ActiveNodes.Where(n => n.NodeId == edge.HeadNodeId || n.NodeId == edge.TailNodeId).Count() == 2)
                {
                    EdgeService.AddEdge(CopiedEdges, edge);
                }
            }
        }

        public async Task Paste()
        {
            int nextNodeId = NodeService.NextId(Nodes);
            PasteOffset += 5 * SVGControl.Scale;
            ActiveNodes.Clear();
            ActiveEdges.Clear();
            foreach (Node node in CopiedNodes) ActiveNodes.Add(NodeService.AddNode(Nodes, node, nextNodeId, PasteOffset));
            foreach (Edge edge in CopiedEdges) ActiveEdges.Add(EdgeService.AddEdge(Edges, edge, nextNodeId));
            await NodesChanged.InvokeAsync(Nodes);
            await EdgesChanged.InvokeAsync(Edges);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task ZoomIn()
        {
            if (SVGControl.Scale > 0.2)
            {
                SVGControl.Scale -= 0.1;
            }
            await SVGControlChanged.InvokeAsync(SVGControl);
        }

        public async Task ZoomOut()
        {
            SVGControl.Scale += 0.1;
            await SVGControlChanged.InvokeAsync(SVGControl);
        }
    }
}