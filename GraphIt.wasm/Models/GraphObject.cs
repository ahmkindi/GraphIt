using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.wasm.Models
{
    public class GraphObject
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Label { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string LabelColor { get; set; }
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string Color { get; set; }
    }
}
