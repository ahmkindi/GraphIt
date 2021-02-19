﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class StartAlgorithm
    {
        private readonly IList<Algorithm> OneInput = new List<Algorithm> { Algorithm.BFS, Algorithm.DFS, Algorithm.Dijkstra};
        private readonly IList<Algorithm> TwoInput = new List<Algorithm> { Algorithm.DijkstraPath, Algorithm.MaxFlow};
        public Algorithm Algorithm { get; set; }
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public AlgorithmType Type { get; set; }
        public string Output { get; set; }
        public bool Ready { get; set; }
        public bool Save { get; set; }
        public bool Done { get; set; }
        public StartAlgorithm(Algorithm a)
        {
            Algorithm = a;
            Save = false;
            Ready = false;
            Done = false;
            if (TwoInput.Contains(a)) Type = AlgorithmType.TwoInput;
            else if (OneInput.Contains(a)) Type = AlgorithmType.OneInput;
            else 
            {
                Type = AlgorithmType.NoInput;
                Ready = true;
            }
        }

        public StartAlgorithm()
        {
            Algorithm = Algorithm.None;
            Ready = false;
            Save = false;
            Done = false;
        }
    }
}
