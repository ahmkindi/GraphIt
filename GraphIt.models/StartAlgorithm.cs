using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class StartAlgorithm
    {
        public Algorithm Algorithm { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }

        public StartAlgorithm(Algorithm a)
        {
            Algorithm = a;
        }
        public StartAlgorithm()
        {
            Algorithm = Algorithm.None;
        }
    }
}
