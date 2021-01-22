using BlazorPro.BlazorSize;
using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class ViewBase : ComponentBase
    {
        [Parameter] public IList<Node> Nodes { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<SVGControl> SVGControlChanged { get; set; }
        [Parameter] public BrowserWindowSize Browser { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        public bool StopZoomIn { get; set; }
        public IList<Node> FilterNodes { get; set; } = new List<Node>();
        public string Filter { get; set; } = "";
        public int Counter { get; set; }
        public BoolButton MatchExact { get; set; } = new BoolButton();
        public BoolButton MatchCase { get; set; } = new BoolButton();
        protected override void OnParametersSet()
        {
            if (Filter == "")
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes) FilterNodes.Add(node);
            }
            if (ActiveNodes.Count == 1 && FilterNodes.Contains(ActiveNodes[0]))
            {
                Counter = FilterNodes.IndexOf(ActiveNodes[0]);
            }
            for (int i = FilterNodes.Count - 1; i >= 0; i--)
            {
                if (!Nodes.Contains(FilterNodes[i])) FilterNodes.RemoveAt(i);
            }
            if (SVGControl.Scale <= 0.2) StopZoomIn = true;
            else StopZoomIn = false;
        }
        public async Task OnScaleClick(double x)
        {
            SVGControl.Scale += x;
            await SVGControlChanged.InvokeAsync(SVGControl);
        }

        public async Task SelectionZoom(ChangeEventArgs e)
        {
            SVGControl.Scale = Double.Parse(e.Value.ToString());
            await SVGControlChanged.InvokeAsync(SVGControl);
        }

        public async Task Fit()
        {
            SVGControl.Xaxis = Nodes.Min(n => n.Xaxis - n.Radius);
            SVGControl.Yaxis = Nodes.Min(n => n.Yaxis - n.Radius) - 105;
            SVGControl.OldXaxis = SVGControl.Xaxis;
            SVGControl.OldYaxis = SVGControl.Yaxis;
            var width = Nodes.Max(n => n.Xaxis + n.Radius) - SVGControl.Xaxis;
            var height = Nodes.Max(n => n.Yaxis + n.Radius) - SVGControl.Yaxis + 30;
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
                if (ActiveNodes.Count == 1 && FilterNodes.Contains(ActiveNodes[0])) Counter = FilterNodes.IndexOf(ActiveNodes[0]);
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
                if (ActiveNodes.Count == 1 && FilterNodes.Contains(ActiveNodes[0])) Counter = FilterNodes.IndexOf(ActiveNodes[0]);
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
                if (ActiveNodes.Count == 1 && FilterNodes.Contains(ActiveNodes[0])) Counter = FilterNodes.IndexOf(ActiveNodes[0]);
                else Counter = 0;
                await IterateNodes(0);
            }
        }

        public async Task IterateNodes(int i)
        {
            Counter = Math.Abs((Counter + i) % FilterNodes.Count);
            ActiveNodes.Clear();
            ActiveNodes.Add(FilterNodes[Counter]);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            await OnRecenter();
        }
        public async Task OnRecenter()
        {
            SVGControl.Xaxis = ActiveNodes[0].Xaxis - (SVGControl.Width / 2);
            SVGControl.Yaxis = ActiveNodes[0].Yaxis - (SVGControl.Height / 2);
            SVGControl.OldXaxis = SVGControl.Xaxis;
            SVGControl.OldYaxis = SVGControl.Yaxis;
            await SVGControlChanged.InvokeAsync(SVGControl);
        }
    }
}
