using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using GraphIt.models;
using GraphIt.web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Pages
{
    public class CanvasBase : ComponentBase
    {
        public Canvas2DContext Context;
        public BECanvasComponent CanvasReference;
        public ElementReference divCanvas;
        [Parameter]
        public DefaultDesign DefaultDesign { get; set; }
        public Offset Offset { get; set; }
        public WindowSize windowSize = new WindowSize
        {
            Height = 0,
            Width = 0
        };
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public INodeService NodeService { get; set; }

        public IEnumerable<Node> Nodes { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Nodes = (await NodeService.GetNodes()).ToList();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                windowSize = await JSRuntime.InvokeAsync<WindowSize>("getWindowSize");
                StateHasChanged();
            }
            else
            {
                Context = await CanvasReference.CreateCanvas2DAsync();
            }
        }

        public async Task Click(MouseEventArgs e)
        {
            if (divCanvas.Id?.Length > 0) 
            {
                Offset = await JSRuntime.InvokeAsync<Offset>("getCanvasOffsets", divCanvas);
                double mouseX = e.ClientX - Offset.Left;
                double mouseY = e.ClientY - Offset.Top;
                await Context.SetFillStyleAsync(DefaultDesign.NodeColor);
                if (Context != null && CanvasReference != null)
                {
                    await Context.MoveToAsync(mouseX, mouseY);
                    await Context.ArcAsync(mouseX, mouseY, DefaultDesign.NodeRadius, 0, Math.PI * 2, true);
                    await Context.FillAsync();
                }
            }
        }
    }
}
