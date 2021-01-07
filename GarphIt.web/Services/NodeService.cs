using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class NodeService : INodeService
    {
        public Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y, string label)
        {
            Node node = new Node
            {
                NodeId = NextId(nodes),
                LabelColor = d.NodeLabelColor,
                NodeColor = d.NodeColor,
                Xaxis = x,
                Yaxis = y,
                Radius = d.NodeRadius,
                Label = label
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y)
        {
            Node node = new Node
            {
                NodeId = NextId(nodes),
                LabelColor = d.NodeLabelColor,
                NodeColor = d.NodeColor,
                Xaxis = x,
                Yaxis = y,
                Radius = d.NodeRadius,
                Label = (nodes.Count + 1).ToString()
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, Node n)
        {
            Node node = new Node
            {
                NodeId = NextId(nodes),
                LabelColor = n.LabelColor,
                NodeColor = n.NodeColor,
                Xaxis = n.Xaxis,
                Yaxis = n.Yaxis,
                Radius = n.Radius,
                Label = n.Label
            };
            nodes.Add(node);
            return node;
        }

        public Node AddNode(IList<Node> nodes, Node n, double offset)
        {
            Node node = new Node
            {
                NodeId = n.NodeId + NextId(nodes),
                LabelColor = n.LabelColor,
                NodeColor = n.NodeColor,
                Xaxis = n.Xaxis + offset,
                Yaxis = n.Yaxis + offset,
                Radius = n.Radius,
                Label = n.Label
            };
            nodes.Add(node);
            return node;
        }

        public void DeleteNode(IList<Node> nodes, IList<Edge> edges, Node node)
        {
            nodes.Remove(node);
            for (int i = edges.Count - 1; i >= 0; i--)
            {
                if (edges[i].TailNodeId == node.NodeId || edges[i].HeadNodeId == node.NodeId) edges.RemoveAt(i);
            }
        }

        public int NextId(IList<Node> nodes)
        {
            if (nodes.Any())
            {
                return nodes.Max(n => n.NodeId) + 1;
            }
            return 0;
        }

    }
}
