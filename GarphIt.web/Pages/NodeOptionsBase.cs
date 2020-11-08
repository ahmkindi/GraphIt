using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
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
        [Inject] public INodeService NodeService { get; set; }

        public async Task OnRadiusChange(ChangeEventArgs e)
        {
            foreach(Node node in ActiveNodes) 
            {
                node.Radius = int.Parse(e.Value.ToString());
            }
            await ActiveNodesChanged.InvokeAsync(ActiveNodes);
        }
        public async Task OnNodeLabelChange(ChangedEventArgs e)
        {
            foreach (Node node in ActiveNodes)
            {
                node.Label = e.Value;
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
            DefaultOptions.NodeRadius = int.Parse(e.Value.ToString());
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }

        public async Task OnRelabel()
        {
            Node newNode;
            int count = 1;
            if (ActiveNodes.Any())
            {
                foreach (Node node in ActiveNodes)
                {
                    newNode = node;
                    newNode.Label = count.ToString();
                    await NodeService.UpdateNode(newNode);
                    count++;
                }
            }
            else
            {
                foreach (Node node in await NodeService.GetNodes())
                {
                    newNode = node;
                    newNode.Label = count.ToString();
                    await NodeService.UpdateNode(newNode);
                    count++;
                }
            }
        }
    }
}
