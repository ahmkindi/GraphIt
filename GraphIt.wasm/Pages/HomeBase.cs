using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GraphIt.wasm.Pages
{
    public class HomeBase : ComponentBase
    {
        [Parameter] public bool MatrixOpened { get; set; }
        [Parameter] public EventCallback<bool> MatrixOpenedChanged { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        [Parameter] public StartAlgorithm StartAlgorithm { get; set; }
        [Parameter] public EventCallback<StartAlgorithm> StartAlgorithmChanged { get; set; }
        [Parameter] public Graph Graph { get; set; }
        [Parameter] public Graph ActiveGraph { get; set; }
        [Parameter] public EventCallback<Graph> ActiveGraphChanged { get; set; }

        public bool GetDegreePref { get; set; } = false;
        public bool[] IsDisabled { get; set; }

        protected override void OnInitialized()
        {
            IsDisabled = new bool[Enum.GetValues(typeof(Algorithm)).Length];
        }
        protected override void OnParametersSet()
        {
            for (int i = 0; i < IsDisabled.Length; i++)
                IsDisabled[i] = false;

            if (!Graph.Nodes.Any())
                for (int i = 0; i < IsDisabled.Length; i++)
                    IsDisabled[i] = true;
            else 
            {
                if (Graph.MultiGraph) IsDisabled[(int)Algorithm.MaxFlow] = true;
                if (!Graph.Weighted) 
                {
                    IsDisabled[(int)Algorithm.MaxFlow] = true;
                    IsDisabled[(int)Algorithm.Dijkstra] = true;
                    IsDisabled[(int)Algorithm.DijkstraPath] = true;
                    IsDisabled[(int)Algorithm.Kruskal] = true;
                }
                else if (Graph.Edges.Any(e => e.Weight <= 0))
                {
                    IsDisabled[(int)Algorithm.MaxFlow] = true;
                    IsDisabled[(int)Algorithm.Dijkstra] = true;
                    IsDisabled[(int)Algorithm.DijkstraPath] = true;
                }
                if (Graph.Directed)
                {
                    IsDisabled[(int)Algorithm.Articulation] = true;
                }
                else
                {
                    IsDisabled[(int)Algorithm.InDegreeCentrality] = true;
                    IsDisabled[(int)Algorithm.OutDegreeCentrality] = true;
                }
            }

        }
        public async Task OnAlgoChanged(Algorithm a)
        {
            await GraphModeChanged.InvokeAsync(GraphMode.Algorithm);
            await StartAlgorithmChanged.InvokeAsync(new StartAlgorithm(a));
        }

        public async Task SelectNodes()
        {
            ActiveGraph.Nodes = Graph.Nodes;
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }

        public async Task SelectEdges()
        {
            ActiveGraph.Edges = Graph.Edges;
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
    }
}
