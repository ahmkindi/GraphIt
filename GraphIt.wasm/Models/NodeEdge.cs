using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.wasm.Models
{
    public class NodeEdge
    {
        public Node Node { get; set; }
        public Edge Edge { get; set; }

        public NodeEdge(Node n, Edge e)
        {
            Node = n;
            Edge = e;
        }

        public NodeEdge(Node n)
        {
            Node = n;
            Edge = null;
        }
    }
}
