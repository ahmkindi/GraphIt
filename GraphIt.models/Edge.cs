using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphIt.models
{
    public class Edge
    {
        public int EdgeId { get; set; }
        [Required]
        [ForeignKey("Node")]
        public int HeadId { get; set; }
        [Required]
        [ForeignKey("Node")]
        public int TailId { get; set; }
        public double Weight { get; set; }
        public string Label { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string EdgeColor { get; set; }
    }
}
