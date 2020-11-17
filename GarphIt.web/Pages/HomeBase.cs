using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class HomeBase : ComponentBase
    {
        [Parameter] public Representation Rep { get; set; }
        [Parameter] public EventCallback<Representation> RepChanged { get; set; }
        public async Task OnMatrixClick()
        {
            Rep = Representation.Matrix;
            await RepChanged.InvokeAsync(Rep);
        }
        public async Task OnWeightMatrixClick()
        {
            Rep = Representation.WeightedMatrix;
            await RepChanged.InvokeAsync(Rep);
        }
    }
}
