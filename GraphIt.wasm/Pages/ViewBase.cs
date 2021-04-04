using BlazorPro.BlazorSize;
using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages
{
    public class ViewBase : ComponentBase
    {
        [Parameter] public IList<Node> Nodes { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<SVGControl> SVGControlChanged { get; set; }
        [Parameter] public BrowserWindowSize Browser { get; set; }
        [Parameter] public Graph ActiveGraph { get; set; }
        [Parameter] public EventCallback<Graph> ActiveGraphChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IZoomService ZoomService { get; set; }
        public IList<Node> FilterNodes { get; set; } = new List<Node>();
        public string Filter { get; set; } = "";
        public int Counter { get; set; }
        public int PercentageZoom { get; set; }
        public BoolButton MatchExact { get; set; } = new BoolButton();
        public BoolButton MatchCase { get; set; } = new BoolButton();
        protected override void OnParametersSet()
        {
            PercentageZoom = ZoomService.GetPercentage(SVGControl.Scale);
            if (Filter == "")
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes) FilterNodes.Add(node);
            }
            if (ActiveGraph.Nodes.Count == 1 && FilterNodes.Contains(ActiveGraph.Nodes[0]))
            {
                Counter = FilterNodes.IndexOf(ActiveGraph.Nodes[0]);
            }
            for (int i = FilterNodes.Count - 1; i >= 0; i--)
            {
                if (!Nodes.Contains(FilterNodes[i])) FilterNodes.RemoveAt(i);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var x = Math.Round(ZoomService.GetMaxScale() - (PercentageZoom / 100.0), 2);
            if (SVGControl.Scale != x)
            {
                SVGControl.Scale = x;
                await SVGControlChanged.InvokeAsync(SVGControl);
            }
        }

        public async Task SelectionZoom(double i)
        {
            SVGControl.Scale = i;
            await SVGControlChanged.InvokeAsync(SVGControl);
        }

        public async Task Fit()
        {
            SVGControl.Xaxis = Nodes.Min(n => n.Xaxis - n.Size);
            SVGControl.Yaxis = Nodes.Min(n => n.Yaxis - n.Size) - 105;
            SVGControl.OldXaxis = SVGControl.Xaxis;
            SVGControl.OldYaxis = SVGControl.Yaxis;
            var width = Nodes.Max(n => n.Xaxis + n.Size) - SVGControl.Xaxis;
            var height = Nodes.Max(n => n.Yaxis + n.Size) - SVGControl.Yaxis + 30;
            SVGControl.Scale = Math.Max(width / Browser.Width, height / Browser.Height); 
            await SVGControlChanged.InvokeAsync(SVGControl);
        }

        public async Task MatchCaseClicked()
        {
            MatchCase.Active = !MatchCase.Active;
            if (MatchCase.Active)
            {
                for (int i = FilterNodes.Count - 1; i >= 0; i--)
                {
                    if (!FilterNodes[i].Label.Contains(Filter)) FilterNodes.RemoveAt(i);
                }
            }
            else
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes)
                {
                    if (node.Label.ToLower().Contains(Filter.ToLower())) FilterNodes.Add(node);
                }
            }
            if (FilterNodes.Any())
            {
                if (ActiveGraph.Nodes.Count == 1 && FilterNodes.Contains(ActiveGraph.Nodes[0])) Counter = FilterNodes.IndexOf(ActiveGraph.Nodes[0]);
                else Counter = 0;
                await IterateNodes(0);
            }
        }

        public async Task MatchExactClicked()
        {
            MatchExact.Active = !MatchExact.Active;
            if (MatchExact.Active)
            {
                for (int i = FilterNodes.Count - 1; i >= 0; i--)
                {
                    if (FilterNodes[i].Label.ToLower() != Filter.ToLower()) FilterNodes.RemoveAt(i);
                }
            }
            else
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes)
                {
                    if (node.Label.ToLower().Contains(Filter.ToLower())) FilterNodes.Add(node);
                }
            }
            if (FilterNodes.Any())
            {
                if (ActiveGraph.Nodes.Count == 1 && FilterNodes.Contains(ActiveGraph.Nodes[0])) Counter = FilterNodes.IndexOf(ActiveGraph.Nodes[0]);
                else Counter = 0;
                await IterateNodes(0);
            }
        }

        public async Task OnLabelChange(ChangeEventArgs e)
        {
            if (e.Value.ToString().Contains(Filter)) 
            {
                for (int i = FilterNodes.Count - 1; i >= 0; i--)
                {
                    if ((MatchCase.Active && !FilterNodes[i].Label.Contains(e.Value.ToString()))
                        || (!MatchCase.Active && !FilterNodes[i].Label.ToLower().Contains(e.Value.ToString().ToLower()))
                        || (MatchExact.Active && FilterNodes[i].Label.ToLower() != e.Value.ToString().ToLower())) 
                            FilterNodes.RemoveAt(i);
                }
            }
            else
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes)
                {
                    if (MatchCase.Active)
                    {
                        if (node.Label.Contains(e.Value.ToString())) FilterNodes.Add(node);
                    }
                    else
                    {
                        if (node.Label.ToLower().Contains(e.Value.ToString().ToLower())) FilterNodes.Add(node);
                    }
                }
                if (MatchExact.Active)
                {
                    for (int i = FilterNodes.Count - 1; i >= 0; i--)
                    {
                        if (FilterNodes[i].Label.ToLower() != e.Value.ToString().ToLower()) FilterNodes.RemoveAt(i);
                    }
                }
            }
            Filter = e.Value.ToString();
            if (FilterNodes.Any())
            {
                if (ActiveGraph.Nodes.Count == 1 && FilterNodes.Contains(ActiveGraph.Nodes[0])) Counter = FilterNodes.IndexOf(ActiveGraph.Nodes[0]);
                else Counter = 0;
                await IterateNodes(0);
            }
        }

        public async Task IterateNodes(int i)
        {
            Counter = Math.Abs((Counter + i) % FilterNodes.Count);
            ActiveGraph.Nodes.Clear();
            ActiveGraph.Nodes.Add(FilterNodes[Counter]);
            await ActiveGraphChanged.InvokeAsync(ActiveGraph);
            await OnRecenter();
        }
        public async Task OnRecenter()
        {
            SVGControl.Xaxis = ActiveGraph.Nodes[0].Xaxis - (SVGControl.Width / 2);
            SVGControl.Yaxis = ActiveGraph.Nodes[0].Yaxis - (SVGControl.Height / 2);
            SVGControl.OldXaxis = SVGControl.Xaxis;
            SVGControl.OldYaxis = SVGControl.Yaxis;
            await SVGControlChanged.InvokeAsync(SVGControl);
        }
    }
}
