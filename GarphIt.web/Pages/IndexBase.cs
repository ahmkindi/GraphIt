﻿using GraphIt.models;
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
        public DefaultDesign DefaultDesign { get; set; }
        public Node ActiveNode { get; set; }
        public Edge ActiveEdge { get; set; }
        public GraphType GraphType { get; set; } = new GraphType
        {
            Weighted = false,
            Directed = false
        };
        public GraphMode GraphMode { get; set; } = GraphMode.Default;
        public bool InitialModal { get; set; } = true;

        public IndexBase()
        {
            DefaultDesign = new DefaultDesign
            {
                NodeColor = "#000000",
                NodeLabelColor = "#ffffff",
                NodeRadius = 50,
                EdgeColor = "#000000",
                EdgeLabelColor = "#000000"
            };
        }

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
