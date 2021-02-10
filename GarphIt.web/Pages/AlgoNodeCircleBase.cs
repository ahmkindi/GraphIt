using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GraphIt.web.Pages
{
    public class AlgoNodeCircleBase : ComponentBase
    {
        [Parameter] public AlgorithmNode AlgorithmNode { get; set; }
    }
}
