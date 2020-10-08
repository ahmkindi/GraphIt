using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Shared
{
    public class DesignBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter]
        public HexColorValue ColorValue { get; set; }
        [Parameter]
        public DefaultDesign DefaultDesign { get; set; }
        [Parameter]
        public EventCallback<DefaultDesign> OnDefaultDesign { get; set; }
        public async Task OnColorChange(ColorPickerEventArgs args, string option)
        {
            ColorValue = ((JObject)args.CurrentValue).ToObject<HexColorValue>();
            if (option == "node")
            {
                DefaultDesign.NodeColor = ColorValue.Hex;
            }
            else if (option == "edge")
            {
                DefaultDesign.EdgeColor = ColorValue.Hex;
            }
            else if (option == "nodeLabel")
            {
                DefaultDesign.NodeLabelColor = ColorValue.Hex;
            }
            else if (option == "edgeLabel")
            {
                DefaultDesign.EdgeLabelColor = ColorValue.Hex;
            }
            else 
            {
                return;
            }
            StateHasChanged();
            await OnDefaultDesign.InvokeAsync(DefaultDesign);
        }
    }
}
