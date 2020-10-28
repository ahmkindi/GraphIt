using System;
using System.Collections.Generic;
using System.Text;

namespace GraphIt.models
{
    public class ObjectClicked
    {
        public bool Node { get; set; } = false;
        public bool Edge { get; set; } = false;
        public bool EdgeRight { get; set; } = false;
        public bool NodeRight { get; set; } = false;
    }
}
