#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bf1e2ab31fa5cec1c092e754ae33b9468d20b56"
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
    public partial class Design : DesignBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar sticky-top navbar-expand navbar-custom py-0 px-0");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "text-center col-md-6 border-right border-dark");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "d-flex flex-row");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<div class=\"font-weight-bold text-left\">\r\n                Default Node:\r\n            </div>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "px-2");
            __builder.AddMarkupContent(12, "\r\n                Radius ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(13);
            __builder.AddAttribute(14, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                               DefaultDesign.NodeRadius

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "CssClass", "radius");
            __builder.AddAttribute(16, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                             10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                    100

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                             1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "Format", "###");
            __builder.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
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
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                             DefaultDesign.NodeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                   OnDefNodeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(29, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "px-2");
            __builder.AddMarkupContent(33, "\r\n                Label ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(34);
            __builder.AddAttribute(35, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                             DefaultDesign.NodeLabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                        OnDefNodeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n");
#nullable restore
#line 20 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
         if (ActiveNode != null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(40, "            ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "d-md-flex flex-row");
            __builder.AddMarkupContent(43, "\r\n                ");
            __builder.AddMarkupContent(44, "<div class=\"font-weight-bold text-left\">\r\n                    Current Node:\r\n                </div>\r\n                ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "px-2");
            __builder.AddMarkupContent(47, "\r\n                    Radius ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(48);
            __builder.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                   ActiveNode.Radius

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                          10

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(51, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                                 100

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(52, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 27 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                                          1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(53, "Format", "###");
            __builder.AddAttribute(54, "CssClass", "radius");
            __builder.AddAttribute(55, "Placeholder", "Radius");
            __builder.AddAttribute(56, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                             ((e) => OnRadiusChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(57, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "px-2");
            __builder.AddMarkupContent(61, "\r\n                    Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(62);
            __builder.AddAttribute(63, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                 ActiveNode.NodeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                    OnNodeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(65, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n                ");
            __builder.OpenElement(67, "div");
            __builder.AddAttribute(68, "class", "px-2");
            __builder.AddMarkupContent(69, "\r\n                    Label\r\n");
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                     if (ActiveNode.Label == null)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(70, "                        ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(71);
            __builder.AddAttribute(72, "CssClass", "radius");
            __builder.AddAttribute(73, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                  OnNodeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(74, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                              ActiveNode.NodeId.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(75, "\r\n");
#nullable restore
#line 38 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(76, "                        ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(77);
            __builder.AddAttribute(78, "CssClass", "radius");
            __builder.AddAttribute(79, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                  OnNodeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(80, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                             ActiveNode.Label

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(81, "\r\n");
#nullable restore
#line 42 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(82, "                    ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(83);
            __builder.AddAttribute(84, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 43 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                           ActiveNode.LabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 43 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                               OnNodeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(86, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n");
#nullable restore
#line 46 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(89, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n    ");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "text-center col-md-6");
            __builder.AddMarkupContent(93, "\r\n        ");
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "d-md-flex flex-row");
            __builder.AddMarkupContent(96, "\r\n            ");
            __builder.AddMarkupContent(97, "<div class=\"font-weight-bold text-left\">\r\n                Default Edge:\r\n            </div>\r\n            ");
            __builder.OpenElement(98, "div");
            __builder.AddAttribute(99, "class", "px-2");
            __builder.AddMarkupContent(100, "\r\n                Width ");
            __Blazor.GraphIt.web.Pages.Design.TypeInference.CreateSfNumericTextBox_0(__builder, 101, 102, 
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                DefaultDesign.EdgeWidth

#line default
#line hidden
#nullable disable
            , 103, 
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                             1

#line default
#line hidden
#nullable disable
            , 104, 
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                   10

#line default
#line hidden
#nullable disable
            , 105, 
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                           0.1

#line default
#line hidden
#nullable disable
            , 106, "radius", 107, "##.#", 108, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 55 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                  ((e) => OnDefWidthChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(109, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n            ");
            __builder.OpenElement(111, "div");
            __builder.AddAttribute(112, "class", "px-2");
            __builder.AddMarkupContent(113, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(114);
            __builder.AddAttribute(115, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                             DefaultDesign.EdgeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(116, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 58 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                   OnDefEdgeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(117, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(118, "\r\n            ");
            __builder.OpenElement(119, "div");
            __builder.AddAttribute(120, "class", "px-2");
            __builder.AddMarkupContent(121, "\r\n                Label ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(122);
            __builder.AddAttribute(123, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 61 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                             DefaultDesign.EdgeLabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(124, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 61 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                        OnDefEdgeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(125, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n");
#nullable restore
#line 64 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
         if (ActiveEdge != null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(128, "            ");
            __builder.OpenElement(129, "div");
            __builder.AddAttribute(130, "class", "d-md-flex flex-row");
            __builder.AddMarkupContent(131, "\r\n                ");
            __builder.AddMarkupContent(132, "<div class=\"font-weight-bold text-left\">\r\n                    Current Edge:\r\n                </div>\r\n                ");
            __builder.OpenElement(133, "div");
            __builder.AddAttribute(134, "class", "px-2");
            __builder.AddMarkupContent(135, "\r\n                    Width ");
            __Blazor.GraphIt.web.Pages.Design.TypeInference.CreateSfNumericTextBox_1(__builder, 136, 137, 
#nullable restore
#line 71 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                    ActiveEdge.Width

#line default
#line hidden
#nullable disable
            , 138, 
#nullable restore
#line 71 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                          1

#line default
#line hidden
#nullable disable
            , 139, 
#nullable restore
#line 71 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                10

#line default
#line hidden
#nullable disable
            , 140, 
#nullable restore
#line 71 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                        0.1

#line default
#line hidden
#nullable disable
            , 141, "radius", 142, "##.#", 143, "Width", 144, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 72 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                          ((e) => OnWidthChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(145, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(146, "\r\n                ");
            __builder.OpenElement(147, "div");
            __builder.AddAttribute(148, "class", "px-2");
            __builder.AddMarkupContent(149, "\r\n                    Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(150);
            __builder.AddAttribute(151, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 75 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                 ActiveEdge.EdgeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(152, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 75 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                    OnEdgeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(153, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(154, "\r\n                ");
            __builder.OpenElement(155, "div");
            __builder.AddAttribute(156, "class", "px-2");
            __builder.AddMarkupContent(157, "\r\n                    Label\r\n");
#nullable restore
#line 79 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                     if (ActiveEdge.Label == null || ActiveEdge.Label == "")
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(158, "                        ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(159);
            __builder.AddAttribute(160, "CssClass", "radius");
            __builder.AddAttribute(161, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 81 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                  OnEdgeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(162, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 81 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                              ActiveEdge.Weight.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(163, "\r\n");
#nullable restore
#line 82 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(164, "                        ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(165);
            __builder.AddAttribute(166, "CssClass", "radius");
            __builder.AddAttribute(167, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 85 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                  OnEdgeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(168, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 85 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                                             ActiveEdge.Label

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(169, "\r\n");
#nullable restore
#line 86 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(170, "                    ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(171);
            __builder.AddAttribute(172, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 87 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                           ActiveEdge.LabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(173, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 87 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
                                                                               OnEdgeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(174, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(175, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(176, "\r\n");
#nullable restore
#line 90 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\Design.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(177, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(178, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.GraphIt.web.Pages.Design
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateSfNumericTextBox_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, TValue __arg1, int __seq2, TValue __arg2, int __seq3, TValue __arg3, int __seq4, global::System.String __arg4, int __seq5, global::System.String __arg5, int __seq6, global::System.Object __arg6)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Inputs.SfNumericTextBox<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "Min", __arg1);
        __builder.AddAttribute(__seq2, "Max", __arg2);
        __builder.AddAttribute(__seq3, "Step", __arg3);
        __builder.AddAttribute(__seq4, "CssClass", __arg4);
        __builder.AddAttribute(__seq5, "Format", __arg5);
        __builder.AddAttribute(__seq6, "onchange", __arg6);
        __builder.CloseComponent();
        }
        public static void CreateSfNumericTextBox_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, TValue __arg1, int __seq2, TValue __arg2, int __seq3, TValue __arg3, int __seq4, global::System.String __arg4, int __seq5, global::System.String __arg5, int __seq6, global::System.String __arg6, int __seq7, global::System.Object __arg7)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Inputs.SfNumericTextBox<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "Min", __arg1);
        __builder.AddAttribute(__seq2, "Max", __arg2);
        __builder.AddAttribute(__seq3, "Step", __arg3);
        __builder.AddAttribute(__seq4, "CssClass", __arg4);
        __builder.AddAttribute(__seq5, "Format", __arg5);
        __builder.AddAttribute(__seq6, "Placeholder", __arg6);
        __builder.AddAttribute(__seq7, "onchange", __arg7);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
