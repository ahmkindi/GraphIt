using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class HomeBase : ComponentBase
    {
        [Parameter] public Representation Rep { get; set; }
        [Parameter] public EventCallback<Representation> RepChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        public async Task OnMatrixClick()
        {
            Rep = Representation.Matrix;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnListClick()
        {
            Rep = Representation.List;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnSimpleChange()
        {
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
        }
    }
}
