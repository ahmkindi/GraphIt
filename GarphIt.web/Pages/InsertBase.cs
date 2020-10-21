using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class InsertBase : ComponentBase
    {
        [Parameter] public GraphMode GraphMode { get; set; }
        [Parameter] public EventCallback<GraphMode> GraphModeChanged { get; set; }
        public bool InsertNode { get; set; }
        public bool InsertEdge { get; set; }

        protected override void OnParametersSet()
        {
            if (GraphMode == GraphMode.InsertNode)
            {
                InsertNode = true;
            }
            else if (GraphMode == GraphMode.InsertNode)
            {
                InsertEdge = true;
            }
        }
        public async Task UpdateInsertNode(ChangeEventArgs e)
        {
            InsertNode = (bool) e.Value;
            if (InsertNode) 
            {
                InsertEdge = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertNode);
            } 
        }

        public async Task UpdateInsertEdge(ChangeEventArgs e)
        {
            InsertEdge = (bool) e.Value;
            if (InsertEdge)
            {
                InsertEdge = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertEdge);
            }
        }
    }
}
