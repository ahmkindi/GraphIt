using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphIt.models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        [Required]
        public double Xaxis { get; set; }
        [Required]
        public double Yaxis { get; set; }
        [Required]
        public int Radius { get; set; }
        public string Label { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [Required]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string NodeColor { get; set; }
        [InverseProperty(nameof(Edge.HeadNode))]
        public virtual ICollection<Edge> HeadEdges { get; set; } = new List<Edge>();
        [InverseProperty(nameof(Edge.TailNode))]
        public virtual ICollection<Edge> TailEdges { get; set; } = new List<Edge>();
    }
}
