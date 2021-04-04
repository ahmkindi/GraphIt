using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class EdgeArrow
    {
        public double[] ArrowOffset { get; set; } = { 4, 1.5 };
        public int Width { get; set; } = 4;
        public int Height { get; set; } = 3;
        public double[] Points { get; set; } = { 0, 0, 4, 1.5, 0, 3 };

    }
}
