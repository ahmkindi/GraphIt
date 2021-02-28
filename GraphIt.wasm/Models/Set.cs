using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.wasm.Models
{
    //ref: https://www.dotnetlovers.com/article/184/disjoint-sets-data-structure
    public class Set
    {
        Dictionary<int, int> parent;
        Dictionary<int, int> rank;

        public Set(IList<Node> nodes)
        {
            parent = new Dictionary<int, int>();
            rank = new Dictionary<int, int>();

            foreach (Node node in nodes)
                parent[node.NodeId] = node.NodeId;
        }

        public void MakeSet(int x)
        {
            parent[x] = x;
            rank[x] = 0;
        }

        public void Union(int x, int y)
        {
            int representativeX = FindSet(x);
            int representativeY = FindSet(y);

            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++;
                parent[representativeX] = representativeY;
            }

            else if (rank[representativeX] > rank[representativeY])
            { parent[representativeY] = representativeX; }
            else
            { parent[representativeX] = representativeY; }
        }

        public int FindSet(int nodeid)
        {
            if (parent[nodeid] != nodeid)
                parent[nodeid] = FindSet(parent[nodeid]);
            return parent[nodeid];
        }

        public int FindImmidiateParent(int x)
        {
            return parent[x];
        }

        public int FindRank(int x)
        {
            return rank[x];
        }
    }
}
