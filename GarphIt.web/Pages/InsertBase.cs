using GraphIt.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        public async Task UpdateInsertNode()
        {
            InsertNode = !InsertNode;
            if (InsertNode) 
            {
                InsertEdge = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertNode);
            }
            else if (!InsertEdge)
            {
                await GraphModeChanged.InvokeAsync(GraphMode.Default);
            }
        }

        public async Task UpdateInsertEdge()
        {
            InsertEdge = !InsertEdge;
            if (InsertEdge)
            {
                InsertNode = false;
                await GraphModeChanged.InvokeAsync(GraphMode.InsertEdge);
            }
            else if (!InsertNode)
            {
                await GraphModeChanged.InvokeAsync(GraphMode.Default);
            }
        }
    }
}
