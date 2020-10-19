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
        [Parameter]
        public bool InsertNode { get; set; }
        [Parameter]
        public EventCallback<bool> InsertNodeChanged { get; set; }

        public async Task UpdateInsertNode(ChangeEventArgs e)
        {
            InsertNode = !InsertNode;
            await InsertNodeChanged.InvokeAsync(InsertNode);
        }
    }
}
