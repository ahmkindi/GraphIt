﻿using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface INodeService
    {
        Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y, string label);
        Node AddNode(IList<Node> nodes, DefaultOptions d, double x, double y);
        void DeleteNode(IList<Node> nodes, IList<Edge> edges, Node node);
        int NextId(IList<Node> nodes);

    }
}
