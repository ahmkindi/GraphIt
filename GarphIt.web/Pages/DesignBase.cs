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
    public class DesignBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public DefaultDesign DefaultDesign { get; set; }
        [Parameter] public EventCallback<DefaultDesign> DefaultDesignChanged { get; set; }
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        [Parameter] public EventCallback<Edge> ActiveEdgeChanged { get; set; }
        public async Task OnDefNodeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultDesign.NodeColor = ColorValue.Hex;
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }
        public async Task OnDefNodeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultDesign.NodeLabelColor = ColorValue.Hex;
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }
        public async Task OnDefRadiusChange(ChangeEventArgs e)
        {
            DefaultDesign.NodeRadius = int.Parse(e.Value.ToString());
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }

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

        public async Task OnDefEdgeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultDesign.EdgeColor = ColorValue.Hex;
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }
        public async Task OnDefEdgeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultDesign.EdgeLabelColor = ColorValue.Hex;
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }
        public async Task OnDefWidthChange(ChangeEventArgs e)
        {
            DefaultDesign.EdgeWidth = double.Parse(e.Value.ToString());
            await DefaultDesignChanged.InvokeAsync(DefaultDesign);
        }

        public async Task OnWidthChange(ChangeEventArgs e)
        {
            ActiveEdge.Width = double.Parse(e.Value.ToString());
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
    }
}
