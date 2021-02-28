using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class EdgeArrow
    {
        public double[] ArrowOffset { get; set; } = { 7, 2.5 };
        public int Width { get; set; } = 7;
        public int Height { get; set; } = 5;
        public double[] Points { get; set; } = { 0, 0, 7, 2.5, 0, 5 };

    }
}
