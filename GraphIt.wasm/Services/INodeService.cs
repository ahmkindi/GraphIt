﻿using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public interface INodeService
    {
        Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y, string label);
        Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y);
        Node AddNode(IList<Node> nodes, Node n);
        Node AddNode(IList<Node> nodes, Node n, int nextNodeId, double offset);
        void DeleteNodes(Graph graph, IList<Node> nodesToDel);
        void DeleteNode(Graph graph, Node node);
        void Align(IList<Node> nodes, string pos);
        int NextId(IList<Node> nodes);

    }
}
