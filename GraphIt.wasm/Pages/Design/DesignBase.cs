using GraphIt.wasm.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphIt.wasm.Pages.Design;

namespace GraphIt.wasm.Pages.Design
{
    public class DesignBase : ComponentBase
    {
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        [Parameter] public IList<Edge> ActiveEdges { get; set; }
        [Parameter] public EventCallback<IList<Edge>> ActiveEdgesChanged { get; set; }
        [Parameter] public EventCallback<bool> DeleteActiveEdges { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public EventCallback<bool> DeleteActiveNodes { get; set; }
        [Parameter] public DefaultOptions DefaultAlgoOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultAlgoOptionsChanged { get; set; }
        public SelectDesign SelectDesign { get; set; }

        protected override void OnParametersSet()
        {
            if (ActiveNodes.Any() && !ActiveEdges.Any()) SelectDesign = SelectDesign.SelectedNode;
            else if (ActiveEdges.Any() && !ActiveNodes.Any()) SelectDesign = SelectDesign.SelectedEdge;
            else if (SelectDesign == SelectDesign.SelectedNode && ActiveNodes.Any()) return;
            else if (SelectDesign == SelectDesign.SelectedEdge && ActiveEdges.Any()) return;
            else SelectDesign = SelectDesign.DefaultNode;
        }

        public string GetText(SelectDesign sd)
        {
            string value = "";
            switch (sd)
            {
                case SelectDesign.DefaultNode:
                    value = "Default Node";
                    break;
                case SelectDesign.DefaultEdge:
                    value = "Default Edge";
                    break;
                case SelectDesign.AlgorithmNode:
                    value = "Algorithm Node";
                    break;
                case SelectDesign.AlgorithmEdge:
                    value = "Algorithm Edge";
                    break;
                case SelectDesign.SelectedNode:
                    value = "Selected Node";
                    break;
                case SelectDesign.SelectedEdge:
                    value = "Selected Edge";
                    break;
            }
            return value;
        }

        public async Task GoDeleteActiveNodes()
        {
            await DeleteActiveNodes.InvokeAsync(true);
        }

        public async Task GoDeleteActiveEdges()
        {
            await DeleteActiveEdges.InvokeAsync(true);
        }
        public async Task GoUpdateActiveNodes()
        {
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }

        public async Task GoUpdateNodes()
        {
            await NodesChanged.InvokeAsync(Nodes);
        }

        public async Task GoUpdateActiveEdges()
        {
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
    }
}
