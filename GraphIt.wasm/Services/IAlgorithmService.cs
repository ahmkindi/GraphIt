using GraphIt.wasm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Services
{
    public interface IAlgorithmService
    {
        void RunAlgorithm(Options options, StartAlgorithm startAlgorithm, Graph graph, AlgoExplain algoExplain, ref List<List<GraphObject>> playAlgorithm);
        void Kruskal();
        //void BFS();
        //void DFS();
        //void Dijkstra();
        //void DijkstraPath();
        //void Degree();
        //void DegreeCentrality(string pref);
        //void FordFulkerson();
        //void Articulation();
    }
}
