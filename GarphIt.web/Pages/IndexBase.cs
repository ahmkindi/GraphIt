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
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public ResizeListener Listener { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public NavChoice? Choice { get; set; }
        public DefaultOptions DefaultOptions { get; set; } = new DefaultOptions();
        public IList<Node> ActiveNodes { get; set; } = new List<Node>();
        public IList<Edge> ActiveEdges { get; set; } = new List<Edge>();
        public GraphMode GraphMode { get; set; } = GraphMode.Default;
        public bool InitialModal { get; set; } = true;
        public Representation Rep { get; set; } = Representation.None;
        public SVGControl SVGControl { get; set; } = new SVGControl();

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Listener.OnResized += WindowResized;
            }
            SVGControl.Width = Browser.Width * SVGControl.Scale;
            SVGControl.Height = Browser.Height * SVGControl.Scale;
        }

        public void UpdateChoice(NavChoice? choice)
        {
            Choice = choice;
        }
        public void OnInitialClose(bool b)
        {
            InitialModal = b;
        }
        public void UpdateCanvas(bool b)
        {
            if (b) StateHasChanged();
        }
        public async Task ActiveNodesChanged(IList<Node> nodes)
        {
            foreach (Node node in nodes.ToList())
            {
                await NodeService.UpdateNode(node);
            }
            ActiveNodes = nodes;
        }

        public async Task ActiveEdgesChanged(IList<Edge> edges)
        {
            foreach (Edge edge in edges.ToList())
            {
                await EdgeService.UpdateEdge(edge);
            }
            ActiveEdges = edges;
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
