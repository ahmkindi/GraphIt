using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class InitialModalBase : ComponentBase
    {
        [Parameter] public DefaultOptions DefaultOptions { get; set; }
        [Parameter] public EventCallback<DefaultOptions> DefaultOptionsChanged { get; set; }
        [Parameter] public EventCallback<bool> OnClose { get; set; }
        public async Task OnSkipClick()
        {
            await OnClose.InvokeAsync(false);
        }

        public async Task OnDoneClick()
        {
            await DefaultOptionsChanged.InvokeAsync(DefaultOptions);
            await OnClose.InvokeAsync(false);
        }
    }
}
