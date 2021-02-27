using Aspose.Svg;
using GraphIt.models;
using GraphIt.web.Models;
using GraphIt.web.Services;
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

namespace GraphIt.web.Pages
{
    public class HomeBase : ComponentBase
    {
        [Parameter] public Representation Rep { get; set; }
        [Parameter] public EventCallback<Representation> RepChanged { get; set; }
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        [Parameter] public StartAlgorithm StartAlgorithm { get; set; }
        [Parameter] public EventCallback<StartAlgorithm> StartAlgorithmChanged { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public IList<Edge> ActiveEdges { get; set; }
        [Parameter] public IList<Node> Nodes { get; set; }
        [Parameter] public IList<Edge> Edges { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public EventCallback<IList<Edge>> ActiveEdgesChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }

        public bool Animate { get; set; } = false;
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

            if (!Nodes.Any())
                for (int i = 0; i < IsDisabled.Length; i++)
                    IsDisabled[i] = true;
            else 
            {
                if (DefaultOptions.MultiGraph) IsDisabled[(int)Algorithm.MaxFlow] = true;
                if (!DefaultOptions.Weighted) 
                {
                    IsDisabled[(int)Algorithm.MaxFlow] = true;
                    IsDisabled[(int)Algorithm.Dijkstra] = true;
                    IsDisabled[(int)Algorithm.DijkstraPath] = true;
                    IsDisabled[(int)Algorithm.Kruskal] = true;
                }
                if (DefaultOptions.Directed)
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
        public async Task OnMatrixClick()
        {
            Rep = Representation.Matrix;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnWeightMatrixClick()
        {
            Rep = Representation.WeightedMatrix;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnAlgoChanged(Algorithm a)
        {
            await GraphModeChanged.InvokeAsync(GraphMode.Algorithm);
            await StartAlgorithmChanged.InvokeAsync(new StartAlgorithm(a));
        }

        public async Task OnSelectAll()
        {
            ActiveNodes.Clear();
            ActiveEdges.Clear();
            foreach (Node node in Nodes) ActiveNodes.Add(node);
            foreach (Edge edge in Edges) ActiveEdges.Add(edge);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
    }
}
