using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class RectSelection
    {
        public bool Create { get; set; } = false;
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
