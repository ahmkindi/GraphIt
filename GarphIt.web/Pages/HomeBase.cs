using Aspose.Svg;
using GraphIt.models;
using GraphIt.web.models;
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
        public bool Animate { get; set; } = false;
        public bool ShowClearModal { get; set; } = false;
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

        public async Task Save()
        {
            StartAlgorithm.Save = true;
            await StartAlgorithmChanged.InvokeAsync(StartAlgorithm);
            ShowClearModal = false;

        }

        public async Task Reset()
        {
            await GraphModeChanged.InvokeAsync(GraphMode.Default);
            await StartAlgorithmChanged.InvokeAsync(new StartAlgorithm());
            ShowClearModal = false;
        }
    }
}
