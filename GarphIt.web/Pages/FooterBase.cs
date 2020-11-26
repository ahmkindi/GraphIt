using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class FooterBase : ComponentBase
    {
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public EventCallback<SVGControl> SVGControlChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
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
    }
}
