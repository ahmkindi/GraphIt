using GraphIt.wasm.Models;
using GraphIt.wasm.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Pages
{
    public class InsertBase : ComponentBase
    {
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Parameter] public Graph Graph { get; set; }
        [Parameter] public EventCallback<Graph> GraphChanged { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public NewEdge NewEdge { get; set; }
        [Parameter] public EventCallback<NewEdge> NewEdgeChanged { get; set; }
        public bool InsertNode { get; set; } = false;
        public bool InsertEdge { get; set; } = false;
        public string NodeCss { get; set; }
        public string EdgeCss { get; set; }
        public bool Loading { get; set; } = false;
        public CommonGraph? WantedGraph { get; set; }
        public int? numNodes { get; set; } = 1;
        public int? KValue { get; set; } = 1;
        public string ErrorCreatingGraph { get; set; } = "";


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
                case CommonGraph.Star:
                    CreateStar();
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
            await GraphChanged.InvokeAsync(Graph);
        }

        private void CreateComplete()
        {
            IList<Node> addedNodes = new List<Node>();
            CreateCircle(addedNodes);
            if (Graph.Directed)
            {
                foreach (Node node1 in addedNodes)
                {
                    foreach (Node node2 in addedNodes)
                    {
                        if (node1 != node2) EdgeService.AddEdge(Graph.Edges, DefaultOptions, node1, node2);
                    }
                }
            }
            else
            {
                IList<Node> Connected = new List<Node>();
                foreach (Node node1 in addedNodes)
                {
                    Connected.Add(node1);
                    foreach (Node node2 in addedNodes)
                    {
                        if (!Connected.Contains(node2)) 
                        {
                            EdgeService.AddEdge(Graph.Edges, DefaultOptions, node1, node2);
                        }
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
                addedNodes1.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            y = (SVGControl.Yaxis + SVGControl.Height / 2) - DefaultOptions.NodeRadius * 3;
            for (int i = 0; i < KValue; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes2.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            if (Graph.Directed)
            {
                foreach (Node node1 in addedNodes1)
                {
                    foreach (Node node2 in addedNodes2)
                    {
                        EdgeService.AddEdge(Graph.Edges, DefaultOptions, node1, node2);
                        EdgeService.AddEdge(Graph.Edges, DefaultOptions, node2, node1);
                    }
                }
            }
            else
            {
                foreach (Node node1 in addedNodes1)
                {
                    foreach (Node node2 in addedNodes2)
                    {
                        EdgeService.AddEdge(Graph.Edges, DefaultOptions, node1, node2);
                    }
                }
            }
        }

        private void CreateStar()
        {
            double x, y;
            double midX = SVGControl.Xaxis + SVGControl.Width / 2;
            double midY = SVGControl.Yaxis + SVGControl.Height / 2;
            double radius = DefaultOptions.NodeRadius / 2 * (double)numNodes;
            double theta = (360.0 / (double)numNodes) * Math.PI / 180;
            IList<Node> addedNodes = new List<Node>();
            Node root = NodeService.AddNode(Graph.Nodes, DefaultOptions, midX, midY, "1");
            for (int i = 1; i < numNodes; i++)
            {
                x = midX + radius * Math.Cos(theta * i);
                y = midY + radius * Math.Sin(theta * i);
                addedNodes.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            foreach (Node node in addedNodes) EdgeService.AddEdge(Graph.Edges, DefaultOptions, node, root);
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
                addedNodes1.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            y = (SVGControl.Yaxis + SVGControl.Height / 2) - DefaultOptions.NodeRadius * 3;
            for (int i = 0; i < numNodes / 2; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes / 2 - i);
                addedNodes2.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            for (int i = 0; i < numNodes / 2; i++)
            {
                for (int k = 0; k < KValue; k++)
                {
                    var xx = (i + k) % addedNodes2.Count;
                    EdgeService.AddEdge(Graph.Edges, DefaultOptions, addedNodes1[i], addedNodes2[xx]);
                    if (Graph.Directed) EdgeService.AddEdge(Graph.Edges, DefaultOptions, addedNodes2[i], addedNodes1[xx]);
                }
            }
        }

        private void CreateCyclic()
        {
            IList<Node> addedNodes = new List<Node>();
            CreateCircle(addedNodes);
            for (int i =0; i < numNodes-1; i++)
            {
                EdgeService.AddEdge(Graph.Edges, DefaultOptions, addedNodes[i], addedNodes[i+1]);
            }
            EdgeService.AddEdge(Graph.Edges, DefaultOptions, addedNodes[(int)numNodes - 1], addedNodes[0]);
        }

        private void CreateTree()
        {
            double x;
            double y = (SVGControl.Yaxis + SVGControl.Height / 2);
            IList<Node> addedNodes = new List<Node>();
            for (int i = 0; i < numNodes; i++)
            {
                x = (SVGControl.Xaxis + SVGControl.Width / 2) + DefaultOptions.NodeRadius * 3 * (double)(numNodes/2 - i);
                addedNodes.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            for (int i = 0; i < numNodes-1; i++)
            {
                EdgeService.AddEdge(Graph.Edges, DefaultOptions, addedNodes[i], addedNodes[i + 1]);
            }
        }

        private void CreateCircle(IList<Node> addedNodes)
        {
            double x, y;
            double radius = DefaultOptions.NodeRadius / 1.5 * (double)numNodes;
            double theta = (360.0 / (double)numNodes) * Math.PI / 180;
            for (int i = 0; i < numNodes; i++)
            {
                x = SVGControl.Xaxis + SVGControl.Width / 2 + radius * Math.Cos(theta * i);
                y = SVGControl.Yaxis + SVGControl.Height / 2 + radius * Math.Sin(theta * i);
                addedNodes.Add(NodeService.AddNode(Graph.Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
        }
    }
}
