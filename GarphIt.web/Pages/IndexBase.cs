using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class IndexBase : ComponentBase
    {

        public NavChoice? Choice { get; set; }
        public DefaultDesign DefaultDesign { get; set; }
        public Node ActiveNode { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (ActiveNode != null)
            {
                await JSRuntime.InvokeAsync<string>("console.log", ActiveNode.NodeId);

            }
        }
        public IndexBase()
        {
            DefaultDesign = new DefaultDesign
            {
                NodeColor = "#000000",
                NodeLabelColor = "#ffffff",
                NodeRadius = 50,
                EdgeColor = "#000000",
                EdgeLabelColor = "#ffffff"
            };
        }

        public void UpdateChoice(NavChoice? choice)
        {
            Choice = choice;
        }
    }
}
