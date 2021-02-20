using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphIt.web.Pages.Design
{
    public class SelectedEdgeBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public IList<Edge> ActiveEdges { get; set; }
        [Parameter] public EventCallback<IList<Edge>> ActiveEdgesChanged { get; set; }
        [Parameter] public EventCallback<bool> DeleteActiveEdges { get; set; }
        public string OpenCss { get; set; }
        public bool Open { get; set; } = false;
        public string NavCss { get; set; }

        public async Task OnWidthChange(ChangeEventArgs e)
        {
            foreach (Edge edge in ActiveEdges)
            {
                edge.Width = int.Parse(e.Value.ToString());
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task OnEdgeLabelChange(ChangeEventArgs e)
        {
            foreach (Edge edge in ActiveEdges)
            {
                edge.Label = e.Value.ToString();
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task OnEdgeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            foreach (Edge edge in ActiveEdges)
            {
                edge.LabelColor = ColorValue.Hex;
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task OnEdgeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            foreach (Edge edge in ActiveEdges)
            {
                edge.EdgeColor = ColorValue.Hex;
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
        public async Task OnWeightChange(ChangeEventArgs e)
        {
            foreach (Edge edge in ActiveEdges)
            {
                edge.Weight = double.Parse(e.Value.ToString());
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }

        public async Task OnCurve(double x)
        {
            foreach (Edge edge in ActiveEdges)
            {
                edge.Curve += x;
            }
            await ActiveEdgesChanged.InvokeAsync(ActiveEdges);
        }
    }
}
