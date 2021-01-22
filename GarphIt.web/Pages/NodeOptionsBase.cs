using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class NodeOptionsBase : ComponentBase
    {
        public class HexColorValue
        {
            public string Hex { get; set; }
        }
        [Parameter] public HexColorValue ColorValue { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        [Parameter] public IList<Node> ActiveNodes { get; set; }
        [Parameter] public EventCallback<IList<Node>> ActiveNodesChanged { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public EventCallback<bool> DeleteActiveNodes { get; set; }
        public string OpenCss { get; set; }
        public bool Open { get; set; } = false;
        public string NavCss { get; set; }

        public async Task OnRadiusChange(ChangeEventArgs e)
        {
            int r = (int) double.Parse(e.Value.ToString());
            if (r < 10) r = 10;
            else if (r > 100) r = 100;
            foreach (Node node in ActiveNodes) 
            {
                node.Radius = r; 
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
                node.NodeColor = ColorValue.Hex;
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnDefNodeColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultOptions.NodeColor = ColorValue.Hex;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefNodeLabelColorChange(ColorPickerEventArgs e)
        {
            ColorValue = ((JObject)e.CurrentValue).ToObject<HexColorValue>();
            DefaultOptions.NodeLabelColor = ColorValue.Hex;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
        public async Task OnDefRadiusChange(ChangeEventArgs e)
        {
            int r = (int)double.Parse(e.Value.ToString());
            if (r < 10) r = 10;
            else if (r > 100) r = 100;
            DefaultOptions.NodeRadius = r;
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }

        public async Task OnRelabel()
        {
            int count = 1;
            if (ActiveNodes.Any())
            {
                foreach (Node node in ActiveNodes)
                {
                    node.Label = count.ToString();
                    count++;
                }
                await ActiveNodesChanged.InvokeAsync(ActiveNodes);
            }
            else
            {
                foreach (Node node in Nodes)
                {
                    node.Label = count.ToString();
                    count++;
                }
                await NodesChanged.InvokeAsync(Nodes);
            }
        }
    }
}
