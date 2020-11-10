using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        [Inject] public IJSRuntime JSRuntime { get; set; }
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
        public int NodeCount { get; set; }
        public bool TextView { get; set; }
        public bool ValidInput { get; set; }
        public bool GetInitText { get; set; }
        public string TextMatrix { get; set; } = "";
        protected override void OnInitialized()
        {
            TextView = false;
            GetInitText = true;
        }
        protected override async Task OnParametersSetAsync()
        {
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
            ValidInput = true;
            NodeCount = Nodes.Count();
        }
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender) GetInitText = true;
            else GetInitText = false;
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
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !edge.Directed))
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
                bool directed;
                if (await RemoveEdge(head, tail)) directed = false;
                else directed = true;
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultOptions.EdgeLabelColor,
                    EdgeColor = DefaultOptions.EdgeColor,
                    HeadNodeId = head.NodeId,
                    TailNodeId = tail.NodeId,
                    Width = DefaultOptions.EdgeWidth,
                    Directed = directed
                };
                await EdgeService.AddEdge(newEdge);
                await UpdateCanvas.InvokeAsync(true);
            }
        }

        public async Task RemoveEdge(ChangeEventArgs e, Node tail, Node head)
        {
            if (int.Parse(e.Value.ToString()) == 0)
            {
                foreach (Edge edge in Edges)
                {
                    if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                        || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !edge.Directed))
                    {
                        await EdgeService.DeleteEdge(edge.EdgeId);
                        if (!edge.Directed)
                        {
                            await AddEdge(head, tail, true);
                        }
                        break;
                    }
                }
                await UpdateCanvas.InvokeAsync(true);
            }
        }

        public async Task<bool> RemoveEdge(Node tail, Node head)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !edge.Directed))
                {
                    await EdgeService.DeleteEdge(edge.EdgeId);
                    Edges = await EdgeService.GetEdges();
                    return true;
                }
            }
            return false;
        }

        public async Task AddEdge(Node tail, Node head, bool directed)
        {
            Edge newEdge = new Edge
            {
                LabelColor = DefaultOptions.EdgeLabelColor,
                EdgeColor = DefaultOptions.EdgeColor,
                HeadNodeId = head.NodeId,
                TailNodeId = tail.NodeId,
                Width = DefaultOptions.EdgeWidth,
                Directed = directed
            };
            await EdgeService.AddEdge(newEdge);
            Edges = await EdgeService.GetEdges();
        }

        public async Task AddNode(string label)
        {
            Node newNode = new Node
            {
                NodeColor = DefaultOptions.NodeColor,
                Label = label,
                LabelColor = DefaultOptions.NodeLabelColor,
                Radius = DefaultOptions.NodeRadius,
                Xaxis = 0,
                Yaxis = 0
            };
            await NodeService.AddNode(newNode);
            Nodes = await NodeService.GetNodes();
        }
        public async Task OnChangeText(ChangeEventArgs e)
        {
            string input = e.Value.ToString();
            string[] rows = ParseInput(input);
            TextMatrix = input;
            if (ValidInput)
            {
                int difference = rows.Length - NodeCount;
                if (difference > 0)
                {
                    for (int i = 1; i <= difference; i++)
                    {
                        await AddNode((NodeCount + i).ToString());
                    }
                }
                else if (difference < 0)
                {
                    for (int i = difference; i < 0; i++)
                    {
                        await NodeService.DeleteNode(Nodes.ElementAt(NodeCount + i).NodeId);
                    }
                    Nodes = await NodeService.GetNodes();
                }
                foreach (Edge edge in Edges)
                {
                    await EdgeService.DeleteEdge(edge.EdgeId);
                }
                Edges = await EdgeService.GetEdges();
                for (int i = 0; i < rows.Length; i++)
                {
                    Node tail = Nodes.ElementAt(i);
                    for (int j = 0; j < rows[i].Length; j++)
                    {
                        Node head = Nodes.ElementAt(j);
                        switch (rows[i][j])
                        {
                            case '1':
                                if (await RemoveEdge(head, tail))
                                {
                                    await AddEdge(tail, head, false);
                                }
                                else await AddEdge(tail, head, true);
                                break;
                        }
                    }
                }
                await UpdateCanvas.InvokeAsync(true);
            }
        }

        public string[] ParseInput(string input)
        {
            var result = Regex.Split(Regex.Replace(input, @"(,|\n$)", ""), "\r\n|\r|\n");
            var regex = @$"^$|(((0|1),){{{result.Length-1}}}(0|1)\n){{{result.Length-1}}}((0|1),){{{result.Length-1}}}(0|1)$";
            ValidInput = Regex.Match(input, regex).Success;
            if (input == "")
            {
                result = new string[0];
            }
            return result;
        }

        public string GetText()
        {
            string value = "";
            foreach(Node tail in Nodes)
            {
                var count = 1;
                foreach (Node head in Nodes)
                {
                    if (Adjacent(tail, head)) value += "1";
                    else value += "0";
                    if (count < NodeCount) value += ",";
                    count++;
                }
                value += "\n";
            }
            return value;
        }
    }
}
