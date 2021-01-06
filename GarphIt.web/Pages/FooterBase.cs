using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class FooterBase : ComponentBase
    {
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public List<Node> Nodes { get; set; }
        [Parameter] public List<Edge> Edges { get; set; }

    }
}
