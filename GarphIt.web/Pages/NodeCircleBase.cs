using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.SplitButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class NodeCircleBase : ComponentBase
    {
        [Parameter]
        public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter]
        public Node Node { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        public async Task OnMouseUp()
        {
            await ActiveNodeChanged.InvokeAsync(Node);
        }
        public async Task OnKeyUp(KeyboardEventArgs e)
        {
            await JSRuntime.InvokeAsync<string>("console.log", e.Key);
        }
    }
}
