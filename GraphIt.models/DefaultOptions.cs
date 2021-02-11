using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class DefaultOptions
    {
        public string NodeColor { get; set; }
        public string NodeLabelColor { get; set; }
        public string EdgeColor { get; set; }
        public string EdgeLabelColor { get; set; }
        public int NodeRadius { get; set; } = 50;
        public int EdgeWidth { get; set; } = 5;
        public bool Weighted { get; set; } = true;
        public bool Directed { get; set; } = true;
        public bool MultiGraph { get; set; } = false;

        public DefaultOptions()
        {
            NodeColor = "#000000";
            NodeLabelColor = "#ffffff";
            EdgeColor = "#000000";
            EdgeLabelColor = "#000000";
        }

        public DefaultOptions(string nColor, string nlColor, string eColor, string elColor)
        {
            NodeColor = nColor;
            NodeLabelColor = nlColor;
            EdgeColor = eColor;
            EdgeLabelColor = elColor;
        }
    }
}
