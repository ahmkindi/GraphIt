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
        [Inject] public IJSRuntime JSRuntime { get; set; }
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
                    await CreateComplete();
                    break;
            }
            WantedGraph = null;
            Loading = false;
        }

        public async Task CreateComplete()
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
                addedNodes.Add(await AddNode(x, y, (i + 1).ToString()));
            }
            if (DefaultOptions.Directed)
            {
                foreach (Node node1 in addedNodes)
                {
                    foreach (Node node2 in addedNodes)
                    {
                        if (node1.NodeId != node2.NodeId) await AddEdge(node1.NodeId, node2.NodeId);
                    }
                }
            }
            else
            {
                IList<Node> notConnected = addedNodes;
                foreach (Node node1 in addedNodes)
                {
                    notConnected.Remove(node1);
                    foreach (Node node2 in notConnected)
                    {
                        await AddEdge(node1.NodeId, node2.NodeId);
                    }
                }
            }
        }

        public async Task<Node> AddNode(double x, double y, string label)
        {
            Node node = new Node()
            {
                Label = label,
                LabelColor = DefaultOptions.NodeLabelColor,
                Xaxis = x,
                Yaxis = y,
                NodeColor = DefaultOptions.NodeColor,
                Radius = DefaultOptions.NodeRadius,
            };
            return await NodeService.AddNode(node);
        }
        public async Task AddEdge(int headId, int tailId)
        {
            Edge edge = new Edge()
            {
                HeadNodeId = headId,
                TailNodeId = tailId,
                EdgeColor = DefaultOptions.EdgeColor,
                Width = DefaultOptions.EdgeWidth,
                LabelColor = DefaultOptions.EdgeLabelColor
            };
            await EdgeService.AddEdge(edge);
        }
    }
}
