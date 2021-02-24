using BlazorPro.BlazorSize;
using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class IndexBase : ComponentBase, IDisposable
    {
        [Inject] public ResizeListener Listener { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public NavChoice? Choice { get; set; }
        public StartAlgorithm StartAlgorithm { get; set; } = new StartAlgorithm();
        public DefaultOptions DefaultOptions { get; set; } = new DefaultOptions();
        public DefaultOptions DefaultAlgoOptions { get; set; } = new DefaultOptions("#ffc400", "#000000", "#ff0000", "#000000");
        public IList<Node> ActiveNodes { get; set; } = new List<Node>();
        public IList<Edge> ActiveEdges { get; set; } = new List<Edge>();
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public GraphMode GraphMode { get; set; } = GraphMode.Default;
        public Representation Rep { get; set; } = Representation.None;
        public NewEdge NewEdge { get; set; } = new NewEdge();
        public SVGControl SVGControl { get; set; } = new SVGControl();

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Listener.OnResized += WindowResized;
            }
        }

        public void UpdateChoice(NavChoice? choice)
        {
            Choice = choice;
        }

        public void DeleteActiveNodes(bool _)
        {
            NodeService.DeleteNodes(Nodes, Edges, ActiveNodes);
            ActiveNodes.Clear();
            if (DefaultOptions.MultiGraph) EdgeService.UpdateMultiGraph(DefaultOptions, Edges);
        }

        public void DeleteActiveEdges(bool _)
        {
            EdgeService.DeleteEdges(Edges, ActiveEdges);
            ActiveEdges.Clear();
            if (DefaultOptions.MultiGraph) EdgeService.UpdateMultiGraph(DefaultOptions, Edges);
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
