using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class SVGControl
    {
        public double Xaxis { get; set; } = 0;
        public double Yaxis { get; set; } = 0;
        public double OldXaxis { get; set; } = 0;
        public double OldYaxis { get; set; } = 0;
        public double Scale { get; set; } = 1;
        public bool Pan { get; set; } = false;
    }
}
