#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74667857e93a71cfdaec1555aa4ba5af3b1d1968"
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
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using BlazorPro.BlazorSize;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
 if (InitialModal)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenComponent<GraphIt.web.Pages.InitialModal>(1);
            __builder.AddAttribute(2, "GraphType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphType>(
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                             GraphType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "OnClose", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                 OnInitialClose

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "\r\n");
            __builder.OpenComponent<GraphIt.web.Pages.NavBar>(6);
            __builder.AddAttribute(7, "OnChoice", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.NavChoice?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.NavChoice?>(this, 
#nullable restore
#line 9 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                  UpdateChoice

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(8, "\r\n\r\n");
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
 if (Choice != null)
{
    switch (Choice)
    {
        case NavChoice.File:

#line default
#line hidden
#nullable disable
            __builder.AddContent(9, "            ");
            __builder.AddMarkupContent(10, @"<nav class=""navbar sticky-top navbar-expand navbar-custom py-0 px-0"">
                <div class=""collapse navbar-collapse mx-0"" id=""navbarNav"">
                    <ul class=""navbar-nav mx-0"">
                        <li class=""nav-item"">
                            <button type=""button"" class=""btn"">Save</button>
                        </li>
                    </ul>
                </div>
            </nav>
");
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Home:

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "            ");
            __builder.AddMarkupContent(12, @"<nav class=""navbar sticky-top navbar-expand navbar-custom py-0 px-0"">
                <div class=""collapse navbar-collapse mx-0"" id=""navbarNav"">
                    <ul class=""navbar-nav mx-0"">
                        <li class=""nav-item"">
                            <button type=""button"" class=""btn"">Save</button>
                        </li>
                    </ul>
                </div>
            </nav>
");
#nullable restore
#line 36 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Insert:

#line default
#line hidden
#nullable disable
            __builder.AddContent(13, "            ");
            __builder.OpenComponent<GraphIt.web.Pages.Insert>(14);
            __builder.AddAttribute(15, "GraphMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphMode>(
#nullable restore
#line 38 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                     GraphMode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "GraphModeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.GraphMode>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.GraphMode>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => GraphMode = __value, GraphMode))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Design:

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "            ");
            __builder.OpenComponent<GraphIt.web.Pages.Design>(19);
            __builder.AddAttribute(20, "ActiveNode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Node>(
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                      ActiveNode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "ActiveNodeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Node>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Node>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => ActiveNode = __value, ActiveNode))));
            __builder.AddAttribute(22, "DefaultDesign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultDesign>(
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                       DefaultDesign

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "DefaultDesignChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.DefaultDesign>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.DefaultDesign>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => DefaultDesign = __value, DefaultDesign))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(24, "\r\n");
#nullable restore
#line 42 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.About:

#line default
#line hidden
#nullable disable
            __builder.AddContent(25, "            ");
            __builder.AddMarkupContent(26, @"<nav class=""navbar sticky-top navbar-expand navbar-custom py-0 px-0"">
                <div class=""collapse navbar-collapse mx-0"" id=""navbarNav"">
                    <ul class=""navbar-nav mx-0"">
                        <li class=""nav-item"">
                            <button type=""button"" class=""btn"">Save</button>
                        </li>
                    </ul>
                </div>
            </nav>
");
#nullable restore
#line 53 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
    }
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(27, "\r\n");
            __builder.OpenComponent<GraphIt.web.Pages.Canvas>(28);
            __builder.AddAttribute(29, "ChangeMenu", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.NavChoice?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.NavChoice?>(this, 
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                UpdateChoice

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(30, "DefaultDesign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultDesign>(
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                       DefaultDesign

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "GraphMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphMode>(
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                 GraphMode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(32, "GraphType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphType>(
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                       GraphType

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "ActiveNode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Node>(
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                          ActiveNode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "ActiveNodeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Node>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Node>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => ActiveNode = __value, ActiveNode))));
            __builder.AddAttribute(35, "ActiveEdge", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Edge>(
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                        ActiveEdge

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "ActiveEdgeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Edge>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Edge>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => ActiveEdge = __value, ActiveEdge))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(37, "\r\n");
            __builder.OpenComponent<GraphIt.web.Pages.Footer>(38);
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
