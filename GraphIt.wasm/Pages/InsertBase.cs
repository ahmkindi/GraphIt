﻿using GraphIt.wasm.Models;
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
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Inject] public INodeService NodeService { get; set; }
        [Inject] public IEdgeService EdgeService { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
        [Parameter] public EventCallback<List<Edge>> EdgesChanged { get; set; }
        [Parameter] public SVGControl SVGControl { get; set; }
        [Parameter] public NewEdge NewEdge { get; set; }
        [Parameter] public EventCallback<NewEdge> NewEdgeChanged { get; set; }
        public bool InsertNode { get; set; }
        public bool InsertEdge { get; set; }
        public string NodeCss { get; set; }
        public string EdgeCss { get; set; }
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
            await NodesChanged.InvokeAsync(Nodes);
            await EdgesChanged.InvokeAsync(Edges);
        }

        private void CreateComplete()
        {
            IList<Node> addedNodes = new List<Node>();
            CreateCircle(addedNodes);
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

        private void CreateStar()
        {
            double x, y;
            double midX = SVGControl.Xaxis + SVGControl.Width / 2;
            double midY = SVGControl.Yaxis + SVGControl.Height / 2;
            double radius = DefaultOptions.NodeRadius / 2 * (double)numNodes;
            double theta = (360.0 / (double)numNodes) * Math.PI / 180;
            IList<Node> addedNodes = new List<Node>();
            Node root = NodeService.AddNode(Nodes, DefaultOptions, midX, midY, "1");
            for (int i = 1; i < numNodes; i++)
            {
                x = midX + radius * Math.Cos(theta * i);
                y = midY + radius * Math.Sin(theta * i);
                addedNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
            foreach (Node node in addedNodes) EdgeService.AddEdge(Edges, DefaultOptions, node.NodeId, root.NodeId);
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
                for (int k = 0; k < KValue; k++)
                {
                    var xx = (i + k) % addedNodes2.Count;
                    EdgeService.AddEdge(Edges, DefaultOptions, addedNodes1[i].NodeId, addedNodes2[xx].NodeId);
                    if (DefaultOptions.Directed) EdgeService.AddEdge(Edges, DefaultOptions, addedNodes2[i].NodeId, addedNodes1[xx].NodeId);
                }
            }
        }

        private void CreateCyclic()
        {
            IList<Node> addedNodes = new List<Node>();
            CreateCircle(addedNodes);
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
            for (int i = 0; i < numNodes-1; i++)
            {
                EdgeService.AddEdge(Edges, DefaultOptions, addedNodes[i].NodeId, addedNodes[i + 1].NodeId);
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
                addedNodes.Add(NodeService.AddNode(Nodes, DefaultOptions, x, y, (i + 1).ToString()));
            }
        }
    }
}