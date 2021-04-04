using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.wasm.Pages
{
    public class CanvasBase : ComponentBase
    {
        [Parameter] public Options Options { get; set; }
        [Parameter] public EventCallback<NavChoice?> ChangeMenu { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        [Parameter] public Graph ActiveGraph { get; set; }
        [Parameter] public EventCallback<Graph> ActiveGraphChanged { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<SVGControl> SVGControlChanged { get; set; }
        [Parameter] public Graph Graph { get; set; }
        [Parameter] public EventCallback<Graph> GraphChanged { get; set; }
        [Parameter] public StartAlgorithm StartAlgorithm { get; set; }
        [Parameter] public EventCallback<StartAlgorithm> StartAlgorithmChanged { get; set; }
        [Parameter] public NewEdge NewEdge { get; set; }
        [Parameter] public EventCallback<NewEdge> NewEdgeChanged { get; set; }
        [Parameter] public EventCallback<string> DeleteActive { get; set; }
        [Parameter] public AlgoExplain AlgoExplain { get; set; }
        [Parameter] public EventCallback<AlgoExplain> AlgoExplainChanged { get; set; }
        [Parameter] public SaveAs SaveAs { get; set; }
        [Parameter] public EventCallback<SaveAs> SaveAsChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public IZoomService ZoomService { get; set; }
        [Inject] public IAlgorithmService AlgorithmService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        public string SvgClass { get; set; }
        public List<List<GraphObject>> PlayAlgorithm = new List<List<GraphObject>>();
        public Graph CopiedGraph { get; set; } = new Graph();
        public ElementReference SVGComponent { get; set; }
        public double PasteOffset { get; set; } = 0;
        private IList<Node> oldNodes { get; set; }
        public SfContextMenu<MenuItem> ObjectContextMenu { get; set; }
        public SfContextMenu<MenuItem> CanvasContextMenu { get; set; }
        public SfContextMenu<MenuItem> AlgorithmContextMenu { get; set; }
        public ObjectClicked ObjectClicked { get; set; } = new ObjectClicked();
        private double[] origin = new double[2];
        public RectSelection RectSelection { get; set; } = new RectSelection();
        public bool MouseDown { get; set; } = false;
        public Graph AlgorithmGraph { get; set; } 

        protected override async Task OnParametersSetAsync()
        {
            if (SaveAs == SaveAs.Full || SaveAs == SaveAs.Page)
            {
                await SaveAsSVG();
            }
            if (GraphMode == GraphMode.Default)
            {
                SvgClass = "grab";
            }
            else if (GraphMode == GraphMode.InsertNode)
            {
                SvgClass = "insert";
            }
            else if (GraphMode == GraphMode.Algorithm)
            {
                if (StartAlgorithm.Ready)
                {
                    if (!StartAlgorithm.Done)
                    {
                        AlgorithmService.RunAlgorithm(Options, StartAlgorithm, Graph, AlgoExplain, ref PlayAlgorithm);
                        await AlgoExplainChanged.InvokeAsync(AlgoExplain);
                        await StartAlgorithmChanged.InvokeAsync(StartAlgorithm);
                    }
                    else
                    {
                        UpdateAlgoGraph();
                    }
                }

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
                    NodeService.Align(ActiveGraph.Nodes, e.Item.Text);
                    break;
                case "Delete":
                    await DeleteActive.InvokeAsync("all");
                    break;
                case "Edit":
                case "Nodes":
                case "Edges":
                    await ChangeMenu.InvokeAsync(NavChoice.Design);
                    break;
                case "All Nodes":
                    await Activate("nodes");
                    break;
                case "All Edges":
                    await Activate("edges");
                    break;
                case "Everything":
                    await Activate("all");
                    break;
                case "Insert Edge":
                    await InsertEdge();
                    break;
                case "Insert Node":
                    NodeService.AddNode(Graph.Nodes, Options.Default, origin[0]*SVGControl.Scale + SVGControl.Xaxis, origin[1]*SVGControl.Scale + SVGControl.Yaxis);
                    await GraphChanged.InvokeAsync(Graph);
                    break;
                case "Stop Algorithm":
                    if (StartAlgorithm.Done) StartAlgorithm.Clear = true;
                    else await Reset();
                    break;
                case "Zoom In":
                    if (ZoomService.ZoomIn(SVGControl)) await SVGControlChanged.InvokeAsync(SVGControl);
                    break;
                case "Zoom Out":
                    if (ZoomService.ZoomOut(SVGControl)) await SVGControlChanged.InvokeAsync(SVGControl);
                    break;
            }
        }

        public async Task InsertEdge()
        {
            if (ActiveGraph.Nodes.Count == 1)
            {
                NewEdge.Tail = ActiveGraph.Nodes[0];
                NewEdge.WaitingForNode = true;
                SvgClass = "ClickNext";
                await NewEdgeChanged.InvokeAsync(NewEdge);
            }
        }

        public void OnRightClick()
        {
            return;
        }
  
        public async Task OnMouseUp(MouseEventArgs e)
        {
            MouseDown = false;
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
                        if (GraphMode == GraphMode.Algorithm)
                        {
                            AlgorithmContextMenu.Open(e.ClientX, e.ClientY);
                        }
                        else
                        {
                            CanvasContextMenu.Open(e.ClientX, e.ClientY);
                            origin[0] = e.ClientX;
                            origin[1] = e.ClientY;
                            if (ActiveGraph.Nodes.Any() || ActiveGraph.Edges.Any()) await ActiveGraphChanged.InvokeAsync(new Graph());
                        }
                    }
                }
                else
                {
                    bool aNodesChanged = false;
                    bool aEdgesChanged = false;
                    foreach (Node node in Graph.Nodes)
                    {
                        if (node.Xaxis <= RectSelection.X + RectSelection.Width
                            && node.Xaxis >= RectSelection.X
                            && node.Yaxis <= RectSelection.Y + RectSelection.Height
                            && node.Yaxis >= RectSelection.Y)
                        {
                            if (!ActiveGraph.Nodes.Contains(node))
                            {
                                ActiveGraph.Nodes.Add(node);
                                aNodesChanged = true;
                            }
                        }
                        else if (ActiveGraph.Nodes.Remove(node)) aNodesChanged = true;
                    }
                    foreach (Edge edge in Graph.Edges)
                    {
                        ShowEdge showEdge = new ShowEdge(edge);
                        var x = 0.25 * edge.Head.Xaxis + 0.5 * showEdge.CurvePoint[0] + 0.25 * edge.Tail.Xaxis;
                        var y = 0.25 * edge.Head.Yaxis + 0.5 * showEdge.CurvePoint[1] + 0.25 * edge.Tail.Yaxis;
                        if (x <= RectSelection.X + RectSelection.Width
                            && x >= RectSelection.X
                            && y <= RectSelection.Y + RectSelection.Height
                            && y >= RectSelection.Y)
                        {
                            if (!ActiveGraph.Edges.Contains(edge))
                            {
                                ActiveGraph.Edges.Add(edge);
                                aEdgesChanged = true;
                            }
                        }
                        else if (ActiveGraph.Edges.Remove(edge)) aEdgesChanged = true;
                    }
                    if (aNodesChanged || aEdgesChanged) await ActiveGraphChanged.InvokeAsync(ActiveGraph);
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
            else if (!e.CtrlKey && !ActiveGraph.Nodes.Any() && !ActiveGraph.Nodes.Any() && GraphMode == GraphMode.InsertNode)
            {
                NodeService.AddNode(Graph.Nodes, Options.Default, e.ClientX*SVGControl.Scale+SVGControl.Xaxis, e.ClientY*SVGControl.Scale+SVGControl.Yaxis);
            }
            else if (ActiveGraph.Nodes.Any() || ActiveGraph.Edges.Any())
            {
                 await ActiveGraphChanged.InvokeAsync(new Graph());
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
            MouseDown = true;
            origin[0] = e.ClientX;
            origin[1] = e.ClientY;
            oldNodes = ActiveGraph.Nodes.Select(n => new Node(n.Id, n.Xaxis, n.Yaxis)).ToList();
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
        public void OnMove(MouseEventArgs e)
        {
            if (MouseDown)
            {
                if (ObjectClicked.Left && ActiveGraph.Nodes.Any())
                {
                    Node oldNode;
                    SvgClass = "moveNode";
                    foreach (Node node in ActiveGraph.Nodes)
                    {
                        oldNode = oldNodes[oldNodes.IndexOf(node)];
                        node.Xaxis = (e.ClientX - origin[0]) * SVGControl.Scale + oldNode.Xaxis;
                        node.Yaxis = (e.ClientY - origin[1]) * SVGControl.Scale + oldNode.Yaxis;
                    }
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
        }
        public async Task OnEdgeClick(Edge edge)
        {
            ActiveGraph = new Graph();
            ActiveGraph.Edges.Add(edge);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
        public async Task AddActiveEdge(Edge edge)
        {
            ActiveGraph.Edges.Add(edge);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
        public async Task RemoveActiveEdge(Edge edge)
        {
            ActiveGraph.Edges.Remove(edge);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
        public async Task OnEdgeRightClick(Edge edge)
        {
            if (!(ActiveGraph.Edges.Count + ActiveGraph.Nodes.Count > 1 && ActiveGraph.Edges.Contains(edge)))
            {
                await OnEdgeClick(edge);
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
            await JustThisNodeActive(node);
            if (NewEdge.WaitingForNode)
            {
                NewEdge.WaitingForNode = false;
                await NewEdgeChanged.InvokeAsync(NewEdge);
                NewEdge.Head = ActiveGraph.Nodes[0];
                NewEdge.MultiEdges = EdgeService.MultiGraphEdges(Graph.Edges, NewEdge.Head, NewEdge.Tail, Graph.Directed);
                if (Graph.Weighted == true)
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
                await InsertEdge();
            }
        }

        public async Task AddActiveNode(Node node)
        {
            ActiveGraph.Nodes.Add(node);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
        public async Task RemoveActiveNode(Node node)
        {
            ActiveGraph.Nodes.Remove(node);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
        public async Task OnNodeRightClick(Node node)
        {
            if (!(ActiveGraph.Edges.Count + ActiveGraph.Nodes.Count > 1 && ActiveGraph.Nodes.Contains(node)))
            {
                await JustThisNodeActive(node);
            }
        }

        public async Task JustThisNodeActive(Node node)
        {
            ActiveGraph = new Graph();
            ActiveGraph.Nodes.Add(node);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }

        public async Task AddNewEdge(bool done)
        {
            if (done && NewEdge.Head != null && NewEdge.Tail != null)
            {
                if (!Graph.MultiGraph && NewEdge.Head == NewEdge.Tail)
                {
                    Graph.MultiGraph = true;
                }
                else if (NewEdge.MultiGraph == false && NewEdge.MultiEdges != null)
                {
                    foreach (Edge edge in NewEdge.MultiEdges) Graph.Edges.Remove(edge);
                }
                else if (!Graph.MultiGraph)
                {
                    Graph.MultiGraph = true;
                }
                if (Graph.Weighted) EdgeService.AddEdge(Graph.Edges, Options.Default, NewEdge.Head, NewEdge.Tail, Math.Round(NewEdge.Weight, 2));
                else EdgeService.AddEdge(Graph.Edges, Options.Default, NewEdge.Head, NewEdge.Tail);
            }
            await NewEdgeChanged.InvokeAsync(new NewEdge());
            await ActiveGraphChanged.InvokeAsync(new Graph());
        }

        public async Task OnScroll(WheelEventArgs e)
        {
            if (e.DeltaY > 0)
            {
                if (ZoomService.ZoomOut(SVGControl)) await SVGControlChanged.InvokeAsync(SVGControl);
            }
            else if (e.DeltaY < 0)
            {
                if (ZoomService.ZoomIn(SVGControl)) await SVGControlChanged.InvokeAsync(SVGControl);
            }
        }

        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            string value = e.Key.ToLower();
            if (value == "delete" || value == "backspace")
            {
                await DeleteActive.InvokeAsync("all");
            }
            if (e.CtrlKey)
            {
                if (e.ShiftKey)
                {
                    if (value == "i") await Activate("nodes");
                    else if (value == "e") await Activate("edges");
                    else if (value == "s") await SaveAsSVG();
                }
                else
                {
                    if (value == "c") Copy();
                    else if (value == "a") await Activate("all");
                }
            }
            else
            {
                if (value == "f") await ChangeMenu.InvokeAsync(NavChoice.File);
                else if (value == "h") await ChangeMenu.InvokeAsync(NavChoice.Home);
                else if (value == "i") await ChangeMenu.InvokeAsync(NavChoice.Insert);
                else if (value == "v") await ChangeMenu.InvokeAsync(NavChoice.View);
                else if (value == "d") await ChangeMenu.InvokeAsync(NavChoice.Design);
                else if (value == "?") await ChangeMenu.InvokeAsync(NavChoice.About);
                else if (value == "x") await ChangeMenu.InvokeAsync(null);
                else if (ActiveGraph.Nodes.Count == 2 && !ActiveGraph.Edges.Any() && value == "c") 
                {
                    NewEdge.Tail = ActiveGraph.Nodes[0];
                    NewEdge.Head = ActiveGraph.Nodes[1];
                    NewEdge.MultiEdges = EdgeService.MultiGraphEdges(Graph.Edges, NewEdge.Head, NewEdge.Tail, Graph.Directed);
                    if (Graph.Weighted)
                    {
                        NewEdge.GetEdgeWeight = true;
                    }
                    else if (!NewEdge.MultiEdges.Any())
                    {
                        await AddNewEdge(true);
                    }
                }
            }
        }

        public async Task OnKeyDown(KeyboardEventArgs e)
        {
            string value = e.Key.ToLower();
            if (!e.ShiftKey)
            {
                if (e.CtrlKey)
                {
                    if (value == "v" && CopiedGraph.Nodes.Any()) await Paste();
                    else if (value == "arrowright") foreach (Edge edge in ActiveGraph.Edges) edge.Curve += 1;
                    else if (value == "arrowleft") foreach (Edge edge in ActiveGraph.Edges) edge.Curve -= 1;
                    else if (value == "arrowup" && Graph.Weighted) foreach (Edge edge in ActiveGraph.Edges) edge.Weight += 1;
                    else if (value == "arrowdown" && Graph.Weighted) foreach (Edge edge in ActiveGraph.Edges) edge.Weight -= 1;
                }
                else
                {
                    if (value == "arrowright") foreach (Node node in ActiveGraph.Nodes) node.Xaxis += 5 * SVGControl.Scale;
                    else if (value == "arrowleft") foreach (Node node in ActiveGraph.Nodes) node.Xaxis -= 5 * SVGControl.Scale;
                    else if (value == "arrowup") foreach (Node node in ActiveGraph.Nodes) node.Yaxis -= 5 * SVGControl.Scale;
                    else if (value == "arrowdown") foreach (Node node in ActiveGraph.Nodes) node.Yaxis += 5 * SVGControl.Scale;
                }
            }
        }

        public void Copy()
        {
            CopiedGraph = new Graph();
            PasteOffset = 0;
            foreach (Node node in ActiveGraph.Nodes)
            {
                NodeService.AddNode(CopiedGraph.Nodes, node);
            }
            foreach (Edge edge in ActiveGraph.Edges)
            {
                if (ActiveGraph.Nodes.Where(n => n == edge.Head || n == edge.Tail).Count() == 2)
                {
                    EdgeService.AddEdge(CopiedGraph.Edges, edge);
                }
            }
        }

        public async Task Paste()
        {
            int nextNodeId = NodeService.NextId(Graph.Nodes);
            PasteOffset += 5 * SVGControl.Scale;
            ActiveGraph = new Graph();
            foreach (Node node in CopiedGraph.Nodes) ActiveGraph.Nodes.Add(NodeService.AddNode(Graph.Nodes, node, nextNodeId, PasteOffset));
            foreach (Edge edge in CopiedGraph.Edges) ActiveGraph.Edges.Add(EdgeService.AddEdge(Graph, edge, nextNodeId));
            await GraphChanged.InvokeAsync(Graph);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }

        public async Task Save()
        {
            Graph.Nodes.Clear();
            Graph.Edges.Clear();
            for (int i = PlayAlgorithm.Count-1; i >= 0; i--)
            {
                foreach (GraphObject obj in PlayAlgorithm[i])
                {
                    if (obj is Node)
                    {
                        Node newNode = new Node(obj as Node);
                        if (!Graph.Nodes.Contains(newNode)) Graph.Nodes.Add(newNode);
                    }
                    else
                    {
                        Edge newEdge = new Edge(obj as Edge);
                        if (!Graph.Edges.Contains(newEdge)) Graph.Edges.Add(newEdge);
                    }
                }
            }
            foreach (Edge edge in Graph.Edges)
            {
                edge.Head = Graph.Nodes.First(n => edge.Head == n);
                edge.Tail = Graph.Nodes.First(n => edge.Tail == n);
            }
            await GraphChanged.InvokeAsync(Graph);
            await Reset();
        }

        public void UpdateAlgoGraph()
        {
            AlgorithmGraph = new Graph();
            for (int i = AlgoExplain.Counter; i >= 0; i--)
            {
                foreach (GraphObject obj in PlayAlgorithm[i])
                {
                    if (obj is Node)
                    {
                        Node newNode = new Node(obj as Node);
                        if (!AlgorithmGraph.Nodes.Contains(newNode)) AlgorithmGraph.Nodes.Add(newNode);
                    }
                    else
                    {
                        Edge newEdge = new Edge(obj as Edge);
                        if (!AlgorithmGraph.Edges.Contains(newEdge)) AlgorithmGraph.Edges.Add(newEdge);
                    }
                }
            }
        }

        public async Task Reset()
        {
            await GraphModeChanged.InvokeAsync(GraphMode.Default);
        }

        public async Task Activate(string type)
        {
            switch (type)
            {
                case "nodes":
                    ActiveGraph.Nodes = Graph.Nodes;
                    await ActiveGraphChanged.InvokeAsync(ActiveGraph);
                    break;
                case "edges":
                    ActiveGraph.Edges = Graph.Edges;
                    await ActiveGraphChanged.InvokeAsync(ActiveGraph);
                    break;
                case "all":
                    await ActiveGraphChanged.InvokeAsync(Graph);
                    break;
            }
        }

        public async Task SaveAsSVG()
        {
            string result;
            MemoryStream stream = new MemoryStream();
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument(false);
                writer.WriteStartElement(null, "svg", "http://www.w3.org/2000/svg");
                writer.WriteAttributeString("version", "1.1");
                if (SaveAs == SaveAs.Full) writer.WriteAttributeString("viewBox", FullView());
                else writer.WriteAttributeString("viewBox", $"{SVGControl.Xaxis} {SVGControl.Yaxis} {SVGControl.Width} {SVGControl.Height}");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
                stream.Seek(0, SeekOrigin.Begin);
                result = reader.ReadToEnd();
            }
            string innerText = await JSRuntime.InvokeAsync<string>("getText", SVGComponent);
            result = result.Insert(result.IndexOf("/>"), $">{innerText}") + "</svg>";
            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", "MyGraph.svg", "image/svg+xml", Encoding.UTF8.GetBytes(result));
            await SaveAsChanged.InvokeAsync(SaveAs.None);
        }

        public string FullView()
        {
            if (Graph.Nodes.Any())
            {
                var x = Graph.Nodes.Min(n => n.Xaxis - n.Size);
                var y = Graph.Nodes.Min(n => n.Yaxis - n.Size);
                var width = Graph.Nodes.Max(n => n.Xaxis + n.Size) - x;
                var height = Graph.Nodes.Max(n => n.Yaxis + n.Size) - y;
                return $"{x} {y} {width} {height}";
            }
            return "0 0 0 0";
        }
    }
}