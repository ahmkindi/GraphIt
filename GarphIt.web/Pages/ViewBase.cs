using BlazorPro.BlazorSize;
using GraphIt.models;
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
        public bool StopZoomIn { get; set; }
        public IList<Node> FilterNodes { get; set; } = new List<Node>();
        public string Filter { get; set; } = "";
        public int Counter { get; set; }
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

        public async Task OnLabelChange(ChangeEventArgs e)
        {
            if (e.Value.ToString().Contains(Filter)) 
            {
                for (int i = FilterNodes.Count - 1; i >= 0; i--)
                {
                    if (!FilterNodes[i].Label.Contains(e.Value.ToString())) FilterNodes.RemoveAt(i);
                }
                if (ActiveNodes.Count == 1 && FilterNodes.Contains(ActiveNodes[0])) Counter = FilterNodes.IndexOf(ActiveNodes[0]);
                else Counter = 0;
            }
            else
            {
                FilterNodes.Clear();
                foreach (Node node in Nodes) if (node.Label.Contains(Filter)) FilterNodes.Add(node);
                if (FilterNodes.Any()) Counter = 0;
            }
            Filter = e.Value.ToString();
            await IterateNodes(0);
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
