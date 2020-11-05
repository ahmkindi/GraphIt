using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class DefaultOptions
    {
        public string NodeColor { get; set; } = "#000000";
        public string NodeLabelColor { get; set; } = "#ffffff";
        public int NodeRadius { get; set; } = 50;
        public string EdgeColor { get; set; } = "#000000";
        public string EdgeLabelColor { get; set; } = "#000000";
        public int EdgeWidth { get; set; } = 5;
        public bool Weighted { get; set; } = true;
        public bool Directed { get; set; } = true;
        public bool MultiGraph { get; set; } = false;
    }
}
