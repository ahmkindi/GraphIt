using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class InsertBase : ComponentBase
    {
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
        [Parameter] public EventCallback<List<Edge>> EdgesChanged { get; set; }
        public bool InsertNode { get; set; }
        public bool InsertEdge { get; set; }
        public bool Loading { get; set; } = false;
        public CommonGraph? WantedGraph { get; set; }
        public int? KValue { get; set; } = 1;

        protected override void OnParametersSet()
        {
            InsertNode = GraphMode == GraphMode.InsertNode;
            InsertEdge = GraphMode == GraphMode.InsertEdge;
        }
        public async Task UpdateInsertNode()
        {
            InsertNode = !InsertNode;
            if (InsertNode) 
            {
                InsertEdge = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertNode);
            }
            else if (!InsertEdge)
            {
                await GraphModeChanged.InvokeAsync(GraphMode.Default);
            }
        }

        public async Task UpdateInsertEdge()
        {
            InsertEdge = !InsertEdge;
            if (InsertEdge)
            {
                InsertNode = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertEdge);
            }
            else if (!InsertNode)
            {
                await GraphModeChanged.InvokeAsync(GraphMode.Default);
            }
        }

        public async Task CreateGraph()
        {
            Loading = true;
            switch (WantedGraph)
            {
                case CommonGraph.Complete:
                    CreateComplete();
                    break;
            }
            WantedGraph = null;
            Loading = false;
            await NodesChanged.InvokeAsync(Nodes);
            await EdgesChanged.InvokeAsync(Edges);
        }

        public void CreateComplete()
        {
            double[] center = { 0, 0 };
            double x, y;
            int radius;
            double theta;
            int level = 0;
            IList<Node> addedNodes = new List<Node>();
            for (int i=0; i<KValue; i++)
            {
                if ((i % 4) == 0 && (i + 4 & (i + 3)) == 0 && i!=0) level++;
                radius = (1 + level) * DefaultOptions.NodeRadius * 4;
                theta = (i % Math.Pow(2,2+level)) * (90/Math.Pow(2, level)) * Math.PI / 180;
                x = center[0] + radius * Math.Cos(theta);
                y = center[1] + radius * Math.Sin(theta);
                addedNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            if (DefaultOptions.Directed)
            {
                foreach (Node node1 in addedNodes)
                {
                    foreach (Node node2 in addedNodes)
                    {
                        if (node1.NodeId != node2.NodeId) EdgeService.AddEdge(Edges, DefaultOptions, node1.NodeId, node2.NodeId);
                    }
                }
            }
            else
            {
                List<Node> notConnected = addedNodes.Select(n => new Node(n.NodeId, n.Xaxis, n.Yaxis)).ToList();
                foreach (Node node1 in addedNodes)
                {
                    notConnected.Remove(node1);
                    foreach (Node node2 in notConnected)
                    {
                        EdgeService.AddEdge(Edges, DefaultOptions, node1.NodeId, node2.NodeId);
                    }
                }
            }
        }
    }
}
