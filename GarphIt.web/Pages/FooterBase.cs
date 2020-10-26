using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class FooterBase : ComponentBase
    {
        public int NodeCount { get; set; } = 0;
        public int EdgeCount { get; set; } = 0;
        [Parameter] public GraphMode GraphMode { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            IEnumerable<Node> nodes = await NodeService.GetNodes();
            IEnumerable<Edge> edges = await EdgeService.GetEdges();
            NodeCount = nodes.Count();
            EdgeCount = edges.Count();
        }
    }
}
