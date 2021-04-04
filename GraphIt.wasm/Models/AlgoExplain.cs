using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace GraphIt.wasm.Models
{
    public class AlgoExplain
    {
        public ConcurrentDictionary<string, List<int>> Explanations { get; set; } = new ConcurrentDictionary<string, List<int>>();
        public int Counter { get; set; } = 0;
        public int MaxCounter { get; set; } = 0;
        public PlaySpeed Speed { get; set; } = PlaySpeed.Normal; 
    }
}
