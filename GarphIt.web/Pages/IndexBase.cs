using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class IndexBase : ComponentBase
    {

        public NavChoice? Choice { get; set; }
        public DefaultOptions DefaultOptions { get; set; } = new DefaultOptions();
        public Node ActiveNode { get; set; }
        public Edge ActiveEdge { get; set; }
        public GraphMode GraphMode { get; set; } = GraphMode.Default;
        public bool InitialModal { get; set; } = true;
        public double Scale { get; set; } = 1;
        public Representation Rep { get; set; } = Representation.None;
        public void UpdateChoice(NavChoice? choice)
        {
            Choice = choice;
        }
        public void OnInitialClose(bool b)
        {
            InitialModal = b;
        }
    }
}
