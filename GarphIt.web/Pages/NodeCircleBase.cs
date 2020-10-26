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
        [Parameter] public EventCallback<Node> ActiveNodeChanged { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Node Node { get; set; }
     
        public async Task OnMouseDown()
        {
            await ActiveNodeChanged.InvokeAsync(Node);
        }
    }
}
