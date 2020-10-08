using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Shared
{
    public class NavBarBase : ComponentBase
    {
        public NavCss[] NavElements { get; set; }
        public NavChoice? Choice { get; set; } = null;

        [Parameter]
        public EventCallback<NavChoice?> OnChoice { get; set; }
        public NavBarBase()
        {
            var length = Enum.GetNames(typeof(NavChoice)).Length;
            NavElements = new NavCss[length];
            for (int i = 0; i < length; i++)
            {
                NavElements[i] = NavCss.NavNone;
            }
        }

        public async Task Click(NavChoice choice)
        {
            if (Choice != null)
            {
                NavElements[(int)this.Choice] = NavCss.NavNone;
            }
            Choice = choice; 
            NavElements[(int)this.Choice] = NavCss.NavActive;
            await OnChoice.InvokeAsync(Choice);
        }

        public async Task Reset()
        {
            if (Choice != null)
            {
                NavElements[(int)this.Choice] = NavCss.NavNone;
                Choice = null;
            }
            await OnChoice.InvokeAsync(Choice);
        }
    }
}
