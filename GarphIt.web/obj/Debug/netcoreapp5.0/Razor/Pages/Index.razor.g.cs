#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1531a12f3de8ecbe82e19c6f1558f1c66b01f20f"
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
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using GraphIt.models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.SplitButtons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\_Imports.razor"
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
            __builder.OpenComponent<GraphIt.web.Pages.InitialModal>(0);
            __builder.AddAttribute(1, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                  DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnClose", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                           OnInitialClose

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.NavBar>(3);
            __builder.AddAttribute(4, "Choice", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.NavChoice?>(
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                      Choice

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "ChoiceChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.NavChoice?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.NavChoice?>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Choice = __value, Choice))));
            __builder.CloseComponent();
#nullable restore
#line 13 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
 if (Choice != null)
{
    switch (Choice)
    {
        case NavChoice.Home:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.Home>(6);
            __builder.AddAttribute(7, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                  DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "SVGControl", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.SVGControl>(
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                              SVGControl

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "UpdateCanvas", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                                        UpdateCanvas

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(10, "Rep", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Representation>(
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                             Rep

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "RepChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Representation>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Representation>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Rep = __value, Rep))));
            __builder.CloseComponent();
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Insert:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.Insert>(12);
            __builder.AddAttribute(13, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 21 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "GraphMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphMode>(
#nullable restore
#line 21 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                     GraphMode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "GraphModeChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.GraphMode>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.GraphMode>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => GraphMode = __value, GraphMode))));
            __builder.CloseComponent();
#nullable restore
#line 22 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Node:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.NodeOptions>(16);
            __builder.AddAttribute(17, "ActiveNodes", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IList<GraphIt.models.Node>>(
#nullable restore
#line 24 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                      ActiveNodes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "ActiveNodesChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.IList<GraphIt.models.Node>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.IList<GraphIt.models.Node>>(this, 
#nullable restore
#line 24 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                       ActiveNodesChanged

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 24 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                                                 DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(20, "DefaultOptionsChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.DefaultOptions>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.DefaultOptions>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => DefaultOptions = __value, DefaultOptions))));
            __builder.AddAttribute(21, "SVGControl", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.SVGControl>(
#nullable restore
#line 24 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                                                                                   SVGControl

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "SVGControlChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.SVGControl>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.SVGControl>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => SVGControl = __value, SVGControl))));
            __builder.CloseComponent();
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Edge:

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.EdgeOptions>(23);
            __builder.AddAttribute(24, "ActiveEdges", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IList<GraphIt.models.Edge>>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                      ActiveEdges

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "ActiveEdgesChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.IList<GraphIt.models.Edge>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.IList<GraphIt.models.Edge>>(this, 
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                       ActiveEdgesChanged

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(26, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                                                 DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(27, "DefaultOptionsChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.DefaultOptions>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.DefaultOptions>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => DefaultOptions = __value, DefaultOptions))));
            __builder.CloseComponent();
#nullable restore
#line 28 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.Algorithms:

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(28, "<nav class=\"navbar sticky-top navbar-expand navbar-custom py-0 px-0\"><div class=\"collapse navbar-collapse mx-0\" id=\"navbarNav\"><ul class=\"navbar-nav mx-0\"><li class=\"nav-item\"><button type=\"button\" class=\"btn\">Save</button></li></ul></div></nav>");
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
        case NavChoice.About:

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(29, "<nav class=\"navbar sticky-top navbar-expand navbar-custom py-0 px-0\"><div class=\"collapse navbar-collapse mx-0\" id=\"navbarNav\"><ul class=\"navbar-nav mx-0\"><li class=\"nav-item\"><button type=\"button\" class=\"btn\">Save</button></li></ul></div></nav>");
#nullable restore
#line 50 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
            break;
    }
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
 if (Rep == Representation.Matrix || Rep == Representation.WeightedMatrix)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.AdjMatrix>(30);
            __builder.AddAttribute(31, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 55 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                               DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(32, "UpdateCanvas", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 55 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                             UpdateCanvas

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(33, "Rep", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.Representation>(
#nullable restore
#line 55 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                          Rep

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "RepChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.Representation>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.Representation>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Rep = __value, Rep))));
            __builder.CloseComponent();
#nullable restore
#line 56 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<GraphIt.web.Pages.Canvas>(35);
            __builder.AddAttribute(36, "ActiveNodes", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IList<GraphIt.models.Node>>(
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                     ActiveNodes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "ActiveNodesChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.IList<GraphIt.models.Node>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.IList<GraphIt.models.Node>>(this, 
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                      ActiveNodesChanged

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(38, "ActiveEdges", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IList<GraphIt.models.Edge>>(
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                     ActiveEdges

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "ActiveEdgesChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Collections.Generic.IList<GraphIt.models.Edge>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Collections.Generic.IList<GraphIt.models.Edge>>(this, 
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                      ActiveEdgesChanged

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(40, "ChangeMenu", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.NavChoice?>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.NavChoice?>(this, 
#nullable restore
#line 59 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                    UpdateChoice

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(41, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 59 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                  DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "GraphMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphMode>(
#nullable restore
#line 59 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                             GraphMode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "SVGControl", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.SVGControl>(
#nullable restore
#line 59 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                                                          SVGControl

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(44, "SVGControlChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.SVGControl>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.SVGControl>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => SVGControl = __value, SVGControl))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(45, "\r\n");
            __builder.OpenComponent<GraphIt.web.Pages.Footer>(46);
            __builder.AddAttribute(47, "GraphMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.GraphMode>(
#nullable restore
#line 60 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                   GraphMode

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "DefaultOptions", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.DefaultOptions>(
#nullable restore
#line 60 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                                            DefaultOptions

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(49, "SVGControl", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<GraphIt.models.SVGControl>(
#nullable restore
#line 60 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Index.razor"
                                                SVGControl

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "SVGControlChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GraphIt.models.SVGControl>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GraphIt.models.SVGControl>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => SVGControl = __value, SVGControl))));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
