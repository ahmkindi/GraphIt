using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphIt.models
{
    public class Edge
    {
        [Key]
        public int EdgeId { get; set; }
        [ForeignKey(nameof(HeadNode))]
        public int HeadNodeId { get; set; }
        [ForeignKey(nameof(TailNode))]
        public int TailNodeId { get; set; }
        public double Curve { get; set; }
        [Required]
        public double Weight { get; set; }
        public string Label { get; set; }
        public int Width { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string EdgeColor { get; set; }
        
        public virtual Node HeadNode { get; set; }
        public virtual Node TailNode { get; set; }
    }
}
