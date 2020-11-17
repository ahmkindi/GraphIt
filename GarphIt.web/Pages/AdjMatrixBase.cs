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
        public Edge AdjEdge { get; set; }
        public string TextMatrix { get; set; } = "";
        protected override void OnInitialized()
        {
            TextView = false;
            GetInitText = true;
            ValidInput = true;
        }
        protected override async Task OnParametersSetAsync()
        {
            Nodes = await NodeService.GetNodes();
            Edges = await EdgeService.GetEdges();
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

        public Edge Adjacent(Node tail, Node head)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !DefaultOptions.Directed))
                {
                    return edge;
                }
            }
            return null;
        }

        public async Task OnChangeTable(ChangeEventArgs e, Node tail, Node head)
        {
            double weight = Math.Round(double.Parse(e.Value.ToString()), 2);
            if (weight > 0)
            {
                await RemoveEdge(tail, head);
                Edge newEdge = new Edge
                {
                    LabelColor = DefaultOptions.EdgeLabelColor,
                    EdgeColor = DefaultOptions.EdgeColor,
                    HeadNodeId = head.NodeId,
                    TailNodeId = tail.NodeId,
                    Width = DefaultOptions.EdgeWidth,
                    Weight = weight
                };
                await EdgeService.AddEdge(newEdge);
            }
            else if (weight == 0)
            {
                foreach (Edge edge in Edges)
                {
                    if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                        || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !DefaultOptions.Directed))
                    {
                        await EdgeService.DeleteEdge(edge.EdgeId);
                        if (!DefaultOptions.Directed)
                        {
                            await AddEdge(head, tail, true, edge.Weight);
                        }
                        break;
                    }
                }
            }
            await UpdateCanvas.InvokeAsync(true);
        }

        public async Task<bool> RemoveEdge(Node tail, Node head)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !DefaultOptions.Directed))
                {
                    await EdgeService.DeleteEdge(edge.EdgeId);
                    Edges = await EdgeService.GetEdges();
                    return true;
                }
            }
            return false;
        }

        public async Task AddEdge(Node tail, Node head, bool directed, double weight)
        {
            Edge newEdge = new Edge
            {
                LabelColor = DefaultOptions.EdgeLabelColor,
                EdgeColor = DefaultOptions.EdgeColor,
                HeadNodeId = head.NodeId,
                TailNodeId = tail.NodeId,
                Width = DefaultOptions.EdgeWidth,
                Weight = weight
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
            double[,] weights = ParseInput(input);
            TextMatrix = input;
            if (ValidInput)
            {
                int difference = weights.GetLength(0) - NodeCount;
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
                for (int i = 0; i < weights.GetLength(0); i++)
                {
                    Node tail = Nodes.ElementAt(i);
                    for (int j = 0; j < weights.GetLength(1); j++)
                    {
                        Node head = Nodes.ElementAt(j);
                        if (weights[i,j] != 0)
                        {
                            if (await RemoveEdge(head, tail))
                            {
                                await AddEdge(tail, head, false, weights[i,j]);
                            }
                            else await AddEdge(tail, head, true, weights[i,j]);
                        }
                    }
                }
                await UpdateCanvas.InvokeAsync(true);
            }
        }

        public double[,] ParseInput(string input)
        {
            string[] temp = Regex.Split(Regex.Replace(input, @"\n$", ""), "\r\n|\r|\n");
            double[,] result = new double[temp.Length, temp.Length];
            string numRegex;
            if (Rep == Representation.Matrix)
            {
                numRegex = "(0|1)";
            }
            else
            {
                numRegex = "[0-9]{1,8}([.][0-9]{1,2})?";
            }
            var regex = @$"^$|^(({numRegex},){{{temp.Length - 1}}}{numRegex}\n){{{temp.Length - 1}}}({numRegex},){{{temp.Length - 1}}}{numRegex}$";
            ValidInput = Regex.Match(input, regex).Success;
            if (ValidInput)
            {
                if (input == "")
                {
                    return new double[0, 0];
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    string[] d = temp[i].Split(',');
                    for (int j = 0; j < d.Length; j++) result[i, j] = double.Parse(d[j]);
                }
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
                    Edge edge = Adjacent(tail, head);
                    if (edge != null) 
                    {
                        if (Rep == Representation.Matrix) value += "1";
                        else value += edge.Weight.ToString();
                    }
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
