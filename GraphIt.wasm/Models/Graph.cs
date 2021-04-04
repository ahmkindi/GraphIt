using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public bool Weighted { get; set; } = true;
        public bool Directed { get; set; } = true;
        public bool MultiGraph { get; set; } = false;
    }
}
