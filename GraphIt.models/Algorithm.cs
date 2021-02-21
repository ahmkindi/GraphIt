using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public enum Algorithm
    {
        None,
        BFS,
        DFS,
        Degree,
        InDegreeCentrality,
        OutDegreeCentrality,
        DegreeCentrality,
        Kruskal,
        Dijkstra,
        DijkstraPath,
        MaxFlow
    }
}
