using GraphIt.wasm.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public class NodeService : INodeService
    {

        [Inject] public IEdgeService EdgeService { get; set; }
        public Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y, string label)
        {
            Node node = new Node
            {
                Id = NextId(nodes),
                LabelColor = d.NodeLabelColor,
                Color = d.NodeColor,
                Xaxis = x,
                Yaxis = y,
                Size = d.NodeRadius,
                Label = label
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y)
        {
            Node node = new Node
            {
                Id = NextId(nodes),
                LabelColor = d.NodeLabelColor,
                Color = d.NodeColor,
                Xaxis = x,
                Yaxis = y,
                Size = d.NodeRadius,
                Label = (nodes.Count + 1).ToString()
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, Node n)
        {
            Node node = new Node
            {
                Id = n.Id,
                LabelColor = n.LabelColor,
                Color = n.Color,
                Xaxis = n.Xaxis,
                Yaxis = n.Yaxis,
                Size = n.Size,
                Label = n.Label
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, Node n, int nextNodeId, double offset)
        {
            Node node = new Node
            {
                Id = n.Id + nextNodeId,
                LabelColor = n.LabelColor,
                Color = n.Color,
                Xaxis = n.Xaxis + offset,
                Yaxis = n.Yaxis + offset,
                Size = n.Size,
                Label = n.Label
            };
            nodes.Add(node);
            return node;
        }

        public void DeleteNode(Graph graph, Node node)
        {
            graph.Nodes.Remove(node);
            for (int i = graph.Edges.Count - 1; i >= 0; i--)
            {
                if (graph.Edges[i].Tail == node || graph.Edges[i].Head == node) graph.Edges.RemoveAt(i);
            }
        }

        public void DeleteNodes(Graph graph, IList<Node> nodesToDel)
        {
            for (int i = nodesToDel.Count-1; i>=0; i--)
                DeleteNode(graph, nodesToDel[i]);
        }

        public void Align(IList<Node> nodes, string pos)
        {
            double minAxis;
            double maxAxis;
            switch (pos)
            {
                case "Left":
                    minAxis = nodes.Min(n => n.Xaxis);
                    foreach (Node node in nodes) node.Xaxis = minAxis;
                    break;
                case "Center":
                    minAxis = nodes.Min(n => n.Xaxis);
                    maxAxis = nodes.Max(n => n.Xaxis);
                    var avg = (maxAxis + minAxis) / 2;
                    foreach (Node node in nodes) node.Xaxis = avg;
                    break;
                case "Right":
                    maxAxis = nodes.Max(n => n.Xaxis);
                    foreach (Node node in nodes) node.Xaxis = maxAxis;
                    break;
                case "Top":
                    minAxis = nodes.Min(n => n.Yaxis);
                    foreach (Node node in nodes) node.Yaxis = minAxis;
                    break;
                case "Middle":
                    minAxis = nodes.Min(n => n.Yaxis);
                    maxAxis = nodes.Max(n => n.Yaxis);
                    var avg2 = (maxAxis + minAxis) / 2;
                    foreach (Node node in nodes) node.Yaxis = avg2;
                    break;
                case "Bottom":
                    maxAxis = nodes.Max(n => n.Yaxis);
                    foreach (Node node in nodes) node.Yaxis = maxAxis;
                    break;
            }
        }

        public int NextId(IList<Node> nodes)
        {
            if (nodes.Any())
            {
                return nodes.Max(n => n.Id) + 1;
            }
            return 0;
        }

    }
}
