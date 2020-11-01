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
    public class EdgeOptionsBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        

        public async Task OnDefWeightedChange()
        {
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefDirectedChange()
        {
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefEdgeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultOptions.EdgeColor = ColorValue.Hex;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefEdgeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultOptions.EdgeLabelColor = ColorValue.Hex;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefWidthChange(ChangeEventArgs e)
        {
            DefaultOptions.EdgeWidth = int.Parse(e.Value.ToString());
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
    }
}
