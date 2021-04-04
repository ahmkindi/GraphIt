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
        [Parameter] public Options Options { get; set; }
        [Parameter] public EventCallback<Options> OptionsChanged { get; set; }
        [Parameter] public Graph ActiveGraph { get; set; }
        [Parameter] public EventCallback<Graph> ActiveGraphChanged { get; set; }
        [Parameter] public bool Weighted { get; set; }
        [Parameter] public EventCallback<bool> Relabel { get; set; }
        [Parameter] public EventCallback<string> DeleteActive { get; set; }
        public SelectDesign SelectDesign { get; set; }

        protected override void OnParametersSet()
        {
            if (ActiveGraph.Nodes.Any() && !ActiveGraph.Edges.Any()) SelectDesign = SelectDesign.SelectedNode;
            else if (ActiveGraph.Edges.Any() && !ActiveGraph.Nodes.Any()) SelectDesign = SelectDesign.SelectedEdge;
            else if (SelectDesign == SelectDesign.SelectedNode && ActiveGraph.Nodes.Any()) return;
            else if (SelectDesign == SelectDesign.SelectedEdge && ActiveGraph.Edges.Any()) return;
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
            await DeleteActive.InvokeAsync("node");
        }

        public async Task GoDeleteActiveEdges()
        {
            await DeleteActive.InvokeAsync("edge");
        }

        public async Task GoUpdateActiveNodes()
        {
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }

        public async Task GoUpdateActiveEdges()
        {
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
        }
    }
}
