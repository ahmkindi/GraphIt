#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d347cd5989d6cba143d7eaec1fa4a3477669064"
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
    public partial class NodeOptions : NodeOptionsBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar sticky-top navbar-expand navbar-custom py-0 px-0");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "text-center border-right border-dark");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "d-flex");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<div class=\"font-weight-bold text-left\">\r\n                Default:\r\n            </div>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "px-2");
            __builder.AddMarkupContent(12, "\r\n                Radius ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(13);
            __builder.AddAttribute(14, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                               DefaultOptions.NodeRadius

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "CssClass", "shortInput");
            __builder.AddAttribute(16, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                             10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                    100

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                             1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "Format", "###");
            __builder.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                       ((e) => OnDefRadiusChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(21, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "px-2");
            __builder.AddMarkupContent(25, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(26);
            __builder.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                             DefaultOptions.NodeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                    OnDefNodeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(29, "ShowButtons", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                                                       false

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "px-2");
            __builder.AddMarkupContent(34, "\r\n                Label ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(35);
            __builder.AddAttribute(36, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                             DefaultOptions.NodeLabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                         OnDefNodeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(38, "ShowButtons", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                                                                 false

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
         if (ActiveNode != null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(41, "            ");
            __builder.AddMarkupContent(42, "<div class=\"font-weight-bold pl-2\">\r\n                Selected:\r\n            </div>\r\n            ");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "px-2");
            __builder.AddMarkupContent(45, "\r\n                Radius ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(46);
            __builder.AddAttribute(47, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                               ActiveNode.Radius

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                      10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(49, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                             100

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 25 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                                      1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(51, "Format", "###");
            __builder.AddAttribute(52, "CssClass", "shortInput");
            __builder.AddAttribute(53, "Placeholder", "Radius");
            __builder.AddAttribute(54, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 26 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                            ((e) => OnRadiusChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(55, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n            ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "px-2");
            __builder.AddMarkupContent(59, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(60);
            __builder.AddAttribute(61, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 29 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                             ActiveNode.NodeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(62, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 29 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                OnNodeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(63, "ShowButtons", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 29 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                                                false

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(64, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n            ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "px-2");
            __builder.AddMarkupContent(68, "\r\n                Label\r\n");
#nullable restore
#line 33 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                 if (ActiveNode.Label == null)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(69, "                    ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(70);
            __builder.AddAttribute(71, "CssClass", "shortInput");
            __builder.AddAttribute(72, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                  OnNodeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(73, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                              ActiveNode.NodeId.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(74, "\r\n");
#nullable restore
#line 36 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(75, "                    ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(76);
            __builder.AddAttribute(77, "CssClass", "shortInput");
            __builder.AddAttribute(78, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                  OnNodeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(79, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                             ActiveNode.Label

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(80, "\r\n");
#nullable restore
#line 40 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(81, "                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(82);
            __builder.AddAttribute(83, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                       ActiveNode.LabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(84, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                           OnNodeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(85, "ShowButtons", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
                                                                                                                false

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(86, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n");
#nullable restore
#line 43 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeOptions.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(88, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591