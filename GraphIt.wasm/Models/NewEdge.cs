using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.wasm.Models
{
    public class NewEdge
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public bool WaitingForNode { get; set; } = false;
        public bool GetEdgeWeight { get; set; } = false;
        public double Weight { get; set; } = 1;
        public IEnumerable<Edge> MultiEdges { get; set; } = new List<Edge>();
        public bool MultiGraph { get; set; } = false;
    }
}
