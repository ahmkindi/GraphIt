using BlazorPro.BlazorSize;
using GraphIt.models;
using Microsoft.AspNetCore.Components;
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
        public bool StopZoomIn { get; set; }
        protected override void OnParametersSet()
        {
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
