using BlazorPro.BlazorSize;
using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages
{
    public class IndexBase : ComponentBase, IDisposable
    {
        [Inject] public ResizeListener Listener { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        public BrowserWindowSize Browser { get; set; } = new BrowserWindowSize();
        public NavChoice? Choice { get; set; }
        public StartAlgorithm StartAlgorithm { get; set; } = new StartAlgorithm();
        public Options Options { get; set; } = new Options("#ffc400", "#000000", "#ff0000", "#000000");
        public Graph ActiveGraph { get; set; } = new Graph();
        public Graph Graph { get; set; } = new Graph();
        public GraphMode GraphMode { get; set; } = GraphMode.Default;
        public bool MatrixOpened { get; set; } = false;
        public NewEdge NewEdge { get; set; } = new NewEdge();
        public SVGControl SVGControl { get; set; } = new SVGControl();
        public AlgoExplain AlgoExplain { get; set; } = new AlgoExplain();
        public SVGSaveAs SVGSaveAs { get; set; } = SVGSaveAs.None;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Listener.OnResized += WindowResized;
            }
            if (Choice != NavChoice.Insert && (GraphMode == GraphMode.InsertNode || GraphMode == GraphMode.InsertEdge))
            {
                GraphMode = GraphMode.Default;
                NewEdge = new NewEdge();
                StateHasChanged();
            }
        }

        public void UpdateChoice(NavChoice? choice)
        {
            Choice = choice;
        }

        public void DeleteActive(string t)
        {
            if (t == "edge" || t == "all") 
            {
                EdgeService.DeleteEdges(Graph.Edges, ActiveGraph.Edges);
                ActiveGraph.Edges.Clear();
            }
            if (t == "node" || t == "all") 
            {
                NodeService.DeleteNodes(Graph, ActiveGraph.Nodes);
                ActiveGraph.Nodes.Clear();
            } 
            if (Graph.MultiGraph) EdgeService.UpdateMultiGraph(Graph);
        }

        public void GraphModeChanged(GraphMode mode)
        {
            GraphMode = mode;
            NewEdge = new NewEdge();
            StartAlgorithm = new StartAlgorithm();
        }

        public void Relabel(bool _)
        {
            int count = 1;
            foreach (Node node in Graph.Nodes)
            {
                node.Label = count.ToString();
                count++;
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
