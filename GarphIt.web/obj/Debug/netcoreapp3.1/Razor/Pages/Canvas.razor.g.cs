#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7fa0ac27215b827253987b49f3250d4918756e6"
// <auto-generated/>
#pragma warning disable 1591
namespace GraphIt.web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations.Internal;

#line default
#line hidden
#nullable disable
    public partial class Canvas : CanvasBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __Blazor.GraphIt.web.Pages.Canvas.TypeInference.CreateSfContextMenu_0(__builder, 0, 1, 
#nullable restore
#line 3 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                       MenuItems

#line default
#line hidden
#nullable disable
            , 2, (__builder2) => {
                __builder2.AddMarkupContent(3, "\r\n    ");
                __builder2.OpenComponent<Syncfusion.Blazor.Navigations.MenuEvents<MenuItem>>(4);
                __builder2.AddAttribute(5, "ItemSelected", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Navigations.MenuEventArgs<MenuItem>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Navigations.MenuEventArgs<MenuItem>>(this, 
#nullable restore
#line 4 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                 Select

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n");
            }
            , 7, (__value) => {
#nullable restore
#line 3 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                        ContextMenu = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "svg");
            __builder.AddAttribute(10, "id", "me");
            __builder.AddAttribute(11, "width", "100%");
            __builder.AddAttribute(12, "height", "100%");
            __builder.AddAttribute(13, "tabindex", "0");
            __builder.AddAttribute(14, "onmousemove", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                                                    OnMove

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "onkeyup", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
               OnKeyUp

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "oncontextmenu", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                        OnRightClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventPreventDefaultAttribute(17, "oncontextmenu", 
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                                                     true

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(18, "onmouseup", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                                                                       OnMouseUp

#line default
#line hidden
#nullable disable
            ));
            __builder.AddElementReferenceCapture(19, (__value) => {
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                              svgCanvas = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.AddMarkupContent(21, @"<defs>
        <pattern id=""smallGrid"" width=""8"" height=""8"" patternUnits=""userSpaceOnUse"">
            <path d=""M 8 0 L 0 0 0 8"" fill=""none"" stroke=""gray"" stroke-width=""0.5""></path>
        </pattern>
        <pattern id=""grid"" width=""80"" height=""80"" patternUnits=""userSpaceOnUse"">
            <rect width=""80"" height=""80"" fill=""url(#smallGrid)""></rect>
            <path d=""M 80 0 L 0 0 0 80"" fill=""none"" stroke=""gray"" stroke-width=""1""></path>
        </pattern>
    </defs>
    <rect width=""100%"" height=""100%"" fill=""url(#smallGrid)""></rect>
");
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
     if (Nodes != null)
    {
        foreach (Node node in Nodes)
        {
            if ((ActiveNode != null && node.NodeId == ActiveNode.NodeId))
            {
                continue;
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(22, "            ");
            __builder.OpenComponent<GraphIt.web.Pages.NodeCircle>(23);
            __builder.AddAttribute(24, "Node", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Node>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                              node

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "ActiveNodeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Node>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Node>(this, 
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                       OnNodeMouseDown

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(26, "\r\n");
#nullable restore
#line 28 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
        }
        if (ActiveNode != null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(27, "            ");
            __builder.OpenComponent<GraphIt.web.Pages.NodeCircle>(28);
            __builder.AddAttribute(29, "Node", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Node>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                              ActiveNode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "ActiveNodeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Node>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Node>(this, 
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                                                             OnNodeMouseDown

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.OpenElement(32, "rect");
            __builder.AddAttribute(33, "x", 
#nullable restore
#line 32 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                       ActiveNode.Xaxis-ActiveNode.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(34, "y", 
#nullable restore
#line 33 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                       ActiveNode.Yaxis-ActiveNode.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(35, "width", 
#nullable restore
#line 34 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                           ActiveNode.Radius*2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(36, "height", 
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
                            ActiveNode.Radius*2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(37, "stroke", "black");
            __builder.AddAttribute(38, "stroke-dasharray", "5,5");
            __builder.AddAttribute(39, "fill", "none");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Canvas.razor"
        }
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.GraphIt.web.Pages.Canvas
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateSfContextMenu_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.List<TValue> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1, int __seq2, global::System.Action<global::Syncfusion.Blazor.Navigations.SfContextMenu<TValue>> __arg2)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Navigations.SfContextMenu<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Items", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.AddComponentReferenceCapture(__seq2, (__value) => { __arg2((global::Syncfusion.Blazor.Navigations.SfContextMenu<TValue>)__value); });
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
