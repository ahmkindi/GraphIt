using System;
using System.Collections.Generic;
using System.Text;
namespace GraphIt.wasm.Models
{
    public class SVGControl
    {
        public double Xaxis { get; set; } = 0;
        public double Yaxis { get; set; } = 0;
        public double Width { get; set; } = 0;
        public double Height { get; set; } = 0;
        public double OldXaxis { get; set; } = 0;
        public double OldYaxis { get; set; } = 0;
        public double Scale { get; set; } = 2.5;
        public bool Pan { get; set; } = false;
    }
}
