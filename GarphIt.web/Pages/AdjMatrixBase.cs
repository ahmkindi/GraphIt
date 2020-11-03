using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class AdjMatrixBase : ComponentBase
    {
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Parameter] public Representation Rep { get; set; }
        [Parameter] public EventCallback<Representation> RepChanged { get; set; }
        public IEnumerable<Node> Nodes { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Nodes = await NodeService.GetNodes();
        }
        public async Task CloseMatrix()
        {
            Rep = Representation.None;
            await RepChanged.InvokeAsync(Rep);
        }
    }
}
