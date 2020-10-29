using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class SelectedBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> ActiveEdgeChanged { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }

        public async Task OnRadiusChange(ChangeEventArgs e)
        {
            ActiveNode.Radius = int.Parse(e.Value.ToString());
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
        }
        public async Task OnNodeLabelChange(ChangedEventArgs e)
        {
            ActiveNode.Label = e.Value.ToString();
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
        }
        public async Task OnNodeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            ActiveNode.LabelColor = ColorValue.Hex;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
        }
        public async Task OnNodeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            ActiveNode.NodeColor = ColorValue.Hex;
            await ActiveNodeChanged.InvokeAsync(ActiveNode);
        }
        public async Task OnWidthChange(ChangeEventArgs e)
        {
            ActiveEdge.Width = int.Parse(e.Value.ToString());
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
        public async Task OnEdgeLabelChange(ChangedEventArgs e)
        {
            ActiveEdge.Label = e.Value.ToString();
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
        public async Task OnEdgeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            ActiveEdge.LabelColor = ColorValue.Hex;
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
        public async Task OnEdgeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            ActiveEdge.EdgeColor = ColorValue.Hex;
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
        public async Task OnWeightChange(ChangeEventArgs e)
        {
            ActiveEdge.Weight = double.Parse(e.Value.ToString());
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }

        public async Task OnDirectedChange()
        {
            ActiveEdge.Directed = !ActiveEdge.Directed;
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
        public async Task OnCurve(double x)
        {     
            ActiveEdge.Curve += x;
            await ActiveEdgeChanged.InvokeAsync(ActiveEdge);
        }
    }
}
