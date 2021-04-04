using GraphIt.wasm.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages.Design
{
    public class SelectedNodeBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public EventCallback<bool> DeleteActiveNodes { get; set; }
        public string OpenCss { get; set; }
        public bool Open { get; set; } = false;
        public string NavCss { get; set; }

        public async Task OnRadiusChange(ChangeEventArgs e)
        {
            int r = (int)double.Parse(e.Value.ToString());
            if (r < 25) r = 25;
            else if (r > 150) r = 150;
            foreach (Node node in ActiveNodes)
            {
                node.Size = r;
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnXaxisChange(ChangeEventArgs e)
        {
            ActiveNodes[0].Xaxis = Math.Round(double.Parse(e.Value.ToString()), 2);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnYaxisChange(ChangeEventArgs e)
        {

            ActiveNodes[0].Yaxis = Math.Round(double.Parse(e.Value.ToString()), 2);
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnNodeLabelChange(ChangeEventArgs e)
        {
            foreach (Node node in ActiveNodes)
            {
                node.Label = e.Value.ToString();
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnNodeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            foreach (Node node in ActiveNodes)
            {
                node.LabelColor = ColorValue.Hex;
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnNodeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            foreach (Node node in ActiveNodes)
            {
                node.Color = ColorValue.Hex;
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }

        public async Task OnRelabel()
        {
            int count = 1;
            foreach (Node node in ActiveNodes)
            {
                node.Label = count.ToString();
                count++;
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
    }
}
