﻿using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class NavBarBase : ComponentBase
    {
        public NavCss[] NavElements { get; set; }
        [Parameter] public NavChoice? Choice { get; set; } = null;
        [Parameter] public EventCallback<NavChoice?> ChoiceChanged { get; set; }
        [Parameter] public Node ActiveNode { get; set; }
        [Parameter] public Edge ActiveEdge { get; set; }
        protected override void OnInitialized()
        {
            var length = Enum.GetNames(typeof(NavChoice)).Length;
            NavElements = new NavCss[length];
        }

        protected override void OnParametersSet()
        {
            for (int i = 0; i < NavElements.Length; i++)
            {
                if (Choice != null && i == (int)Choice) NavElements[(int)this.Choice] = NavCss.NavActive;
                else NavElements[i] = NavCss.NavNone;
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
            await ChoiceChanged.InvokeAsync(Choice);
        }

        public async Task Reset()
        {
            if (Choice != null)
            {
                NavElements[(int)this.Choice] = NavCss.NavNone;
                Choice = null;
            }
            await ChoiceChanged.InvokeAsync(Choice);
        }
    }
}
