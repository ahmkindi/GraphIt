using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class Options
    {
        public DefaultOptions Default { get; set; }
        public DefaultOptions Algorithm { get; set; }

        public Options()
        {
            Default = new DefaultOptions();
            Algorithm = new DefaultOptions();
        }

        public Options(string nodeC, string nodeLabelC, string edgeC, string edgeLabelC)
        {
            Default = new DefaultOptions();
            Algorithm = new DefaultOptions(nodeC, nodeLabelC, edgeC, edgeLabelC);
        }
    }
}
