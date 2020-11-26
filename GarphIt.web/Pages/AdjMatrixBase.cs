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
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }
        [Parameter] public EventCallback<List<Node>> NodesChanged { get; set; }
        [Parameter] public EventCallback<List<Edge>> EdgesChanged { get; set; }
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
                RemoveEdge(tail, head);
                EdgeService.AddEdge(Edges, DefaultOptions, head.NodeId, tail.NodeId, weight);
            }
            else if (weight == 0)
            {
                foreach (Edge edge in Edges)
                {
                    if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                        || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !DefaultOptions.Directed))
                    {
                        Edges.Remove(edge);
                        if (!DefaultOptions.Directed)
                        {
                            EdgeService.AddEdge(Edges, DefaultOptions, head.NodeId, tail.NodeId, edge.Weight);
                        }
                        break;
                    }
                }
            }
            await EdgesChanged.InvokeAsync(Edges);
        }

        public void RemoveEdge(Node tail, Node head)
        {
            foreach (Edge edge in Edges)
            {
                if ((edge.HeadNodeId == head.NodeId && edge.TailNodeId == tail.NodeId)
                    || (edge.HeadNodeId == tail.NodeId && edge.TailNodeId == head.NodeId && !DefaultOptions.Directed))
                {
                    Edges.Remove(edge);
                }
            }
        }

        public async Task OnChangeText(ChangeEventArgs e)
        {
            string input = e.Value.ToString();
            double[,] weights = ParseInput(input);
            TextMatrix = input;
            if (ValidInput)
            {
                int difference = weights.GetLength(0) - Nodes.Count;
                if (difference > 0)
                {
                    for (int i = 1; i <= difference; i++)
                    {
                        NodeService.AddNode(Nodes, DefaultOptions, 0, 0);
                    }
                }
                else if (difference < 0)
                {
                    for (int i = difference; i < 0; i++)
                    {
                        Nodes.Remove(Nodes[Nodes.Count + i]);
                    }
                }
                Edges.Clear();
                for (int i = 0; i < weights.GetLength(0); i++)
                {
                    for (int j = 0; j < weights.GetLength(1); j++)
                    {
                        if (weights[i,j] != 0) EdgeService.AddEdge(Edges, DefaultOptions, Nodes[j].NodeId, Nodes[i].NodeId, weights[i,j]);
                    }
                }
                await NodesChanged.InvokeAsync(Nodes);
                await EdgesChanged.InvokeAsync(Edges);
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
                    if (count < Nodes.Count) value += ",";
                    count++;
                }
                value += "\n";
            }
            return value;
        }
    }
}
