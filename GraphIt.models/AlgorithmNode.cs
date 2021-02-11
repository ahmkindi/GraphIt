﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class AlgorithmNode : IEquatable<AlgorithmNode>
    {
        public string Header { get; set; }
        public Node Node { get; set; }

        public AlgorithmNode(Node node)
        {
            Node = new Node(node);
        }

        public bool Equals(AlgorithmNode other)
        {
            if (this.Node.NodeId == other.Node.NodeId) return true;
            return false;
        }
    }
}
