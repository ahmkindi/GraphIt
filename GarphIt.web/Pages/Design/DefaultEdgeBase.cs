using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages.Design
{
    public class DefaultEdgeBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        public string OpenCss { get; set; }
        public bool Open { get; set; } = false;
        public string NavCss { get; set; }

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
            int w = (int)double.Parse(e.Value.ToString());
            if (w < 2) w = 2;
            else if (w > 20) w = 20;
            DefaultOptions.EdgeWidth = w;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
    }
}
