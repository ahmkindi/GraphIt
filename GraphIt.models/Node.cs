using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraphIt.models
{
    public class Node
    {
        public int NodeId { get; set; }
        [Required]
        public double Xaxis { get; set; }
        [Required]
        public double Yaxis { get; set; }
        public string Label { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string NodeColor { get; set; }
    }
}
