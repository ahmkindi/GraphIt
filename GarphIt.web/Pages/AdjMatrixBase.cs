using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;
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
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<bool> UpdateCanvas { get; set; }
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
        }
        public async Task CloseMatrix()
        {
            Rep = Representation.None;
            await RepChanged.InvokeAsync(Rep);
        }

        public bool Adjacent(Node tail, Node head)
        {
            foreach (Edge edge in Edges)
            {
                if (edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task AddEdge(ChangeEventArgs e, Node tail, Node head)
        {
            if (int.Parse(e.Value.ToString()) == 1)
            {
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultOptions.EdgeLabelColor,
                    EdgeColor = DefaultOptions.EdgeColor,
                    HeadNodeId = head.NodeId,
                    TailNodeId = tail.NodeId,
                    Width = DefaultOptions.EdgeWidth,
                    Directed = DefaultOptions.Directed
                };
                await EdgeService.AddEdge(newEdge);
                Edges = await EdgeService.GetEdges();
                await UpdateCanvas.InvokeAsync(true);
            }
        }

        public async Task RemoveEdge(ChangeEventArgs e, Node tail, Node head)
        {
            if (int.Parse(e.Value.ToString()) == 0)
            {
                foreach (Edge edge in Edges)
                {
                    if (edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    {
                        await EdgeService.DeleteEdge(edge.EdgeId);
                        Edges = await EdgeService.GetEdges();
                        await UpdateCanvas.InvokeAsync(true);
                        break;
                    }
                }
            }
        }
    }
}
