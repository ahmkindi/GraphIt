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
        [Parameter] public SVGControl SVGControl { get; set; }
        public bool InsertNode { get; set; }
        public bool InsertEdge { get; set; }
        public bool Loading { get; set; } = false;
        public CommonGraph? WantedGraph { get; set; }
        public int? numNodes { get; set; } = 1;
        public int? KValue { get; set; } = 1;
        public string ErrorCreatingGraph { get; set; } = "";


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
                case CommonGraph.CBipartite:
                    CreateCBipartite();
                    break;
                case CommonGraph.Regular:
                    if (KValue < numNodes && (numNodes % 2 == 0 || KValue % 2 == 0)) CreateRegular();
                    else ErrorCreatingGraph = "for a K-Regular to exist it must satisfy: K < n AND if K is odd then n is even ";
                    break;
                case CommonGraph.Cyclic:
                    if (numNodes > 2) CreateCyclic();
                    else ErrorCreatingGraph = "For a cyclic graph you need at least 3 nodes (assuming simple graph)";
                    break;
                case CommonGraph.RBipartite:
                    if (numNodes % 2 == 0 && KValue <= numNodes / 2) CreateRBipartite();
                    else ErrorCreatingGraph = "k-Regular Bipartite graph must satisfy: Even number of nodes AND K is at most half the number of nodes";
                    break;
                case CommonGraph.Tree:
                    CreateTree();
                    break;

            }
            WantedGraph = null;
            Loading = false;
            await NodesChanged.InvokeAsync(Nodes);
            await EdgesChanged.InvokeAsync(Edges);
        }

        private void CreateComplete()
        {
            double x, y;
            int radius;
            double theta;
            int level = 0;
            IList<Node> addedNodes = new List<Node>();
            for (int i=0; i<numNodes; i++)
            {
                if ((i % 4) == 0 && (i + 4 & (i + 3)) == 0 && i!=0) level++;
                radius = (1 + level) * DefaultOptions.NodeRadius * 4;
                theta = (i % Math.Pow(2,2+level)) * (90/Math.Pow(2, level)) * Math.PI / 180;
                x = SVGControl.Xaxis + SVGControl.Width/2 + radius * Math.Cos(theta);
                y = SVGControl.Yaxis + SVGControl.Height/2 + radius * Math.Sin(theta);
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

        private void CreateCBipartite()
        {
            double x;
            double y = (SVGControl.Yaxis + SVGControl.Height / 2) + DefaultOptions.NodeRadius * 3;
            IList<Node> addedNodes1 = new List<Node>();
            IList<Node> addedNodes2 = new List<Node>();
            for (int i=0; i<numNodes; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes1.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            y = (SVGControl.Yaxis + SVGControl.Height / 2) - DefaultOptions.NodeRadius * 3;
            for (int i = 0; i < KValue; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes2.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            if (DefaultOptions.Directed)
            {
                foreach (Node node1 in addedNodes1)
                {
                    foreach (Node node2 in addedNodes2)
                    {
                        EdgeService.AddEdge(Edges, DefaultOptions, node1.NodeId, node2.NodeId);
                        EdgeService.AddEdge(Edges, DefaultOptions, node2.NodeId, node1.NodeId);
                    }
                }
            }
            else
            {
                foreach (Node node1 in addedNodes1)
                {
                    foreach (Node node2 in addedNodes2)
                    {
                        EdgeService.AddEdge(Edges, DefaultOptions, node1.NodeId, node2.NodeId);
                    }
                }
            }
        }

        private void CreateRegular()
        {
            double x, y;
            double radius = (DefaultOptions.NodeRadius/2) * (double)numNodes;
            double theta = (360.0 / (double)numNodes) * Math.PI / 180;
            IList<Node> evenNodes = new List<Node>();
            IList<Node> oddNodes = new List<Node>();
            for (int i = 0; i < numNodes; i++)
            {
                x = SVGControl.Xaxis + SVGControl.Width / 2 + radius * Math.Cos(theta*i);
                y = SVGControl.Yaxis + SVGControl.Height / 2 + radius * Math.Sin(theta*i);
                if (i%2 == 0) evenNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
                else oddNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
        }

        private void CreateRBipartite()
        {
            double x;
            double y = (SVGControl.Yaxis + SVGControl.Height / 2) + DefaultOptions.NodeRadius * 3;
            IList<Node> addedNodes1 = new List<Node>();
            IList<Node> addedNodes2 = new List<Node>();
            for (int i = 0; i < numNodes / 2; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes1.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            y = (SVGControl.Yaxis + SVGControl.Height / 2) - DefaultOptions.NodeRadius * 3;
            for (int i = 0; i < numNodes / 2; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes2.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            for (int i = 0; i < numNodes / 2; i++)
            {
                for (int j = 0; j < KValue; j++)
                {
                    EdgeService.AddEdge(Edges, DefaultOptions, addedNodes1[i].NodeId, addedNodes2[j].NodeId);
                    if (DefaultOptions.Directed) EdgeService.AddEdge(Edges, DefaultOptions, addedNodes2[i].NodeId, addedNodes1[j].NodeId);
                }
            }
        }

        private void CreateCyclic()
        {
            double x, y;
            double radius = DefaultOptions.NodeRadius/1.5 * (double)numNodes;
            double theta = (360.0 / (double)numNodes) * Math.PI / 180;
            IList<Node> addedNodes = new List<Node>();
            for (int i = 0; i < numNodes; i++)
            {
                x = SVGControl.Xaxis + SVGControl.Width / 2 + radius * Math.Cos(theta * i);
                y = SVGControl.Yaxis + SVGControl.Height / 2 + radius * Math.Sin(theta * i);
                addedNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            for (int i =0; i < numNodes-1; i++)
            {
                EdgeService.AddEdge(Edges, DefaultOptions, addedNodes[i].NodeId, addedNodes[i+1].NodeId);
            }
            EdgeService.AddEdge(Edges, DefaultOptions, addedNodes[(int)numNodes - 1].NodeId, addedNodes[0].NodeId);
        }

        private void CreateTree()
        {
            double x;
            double y = (SVGControl.Yaxis + SVGControl.Height / 2);
            IList<Node> addedNodes = new List<Node>();
            for (int i = 0; i < numNodes; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes/2 - i);
                addedNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
        }
    }
}
