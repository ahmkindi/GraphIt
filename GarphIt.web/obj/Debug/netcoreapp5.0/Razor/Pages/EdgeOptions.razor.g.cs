#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5199a24aa7338821deca2d208d5553353876939"
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
    public partial class EdgeOptions : EdgeOptionsBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar sticky-top navbar-expand navbar-custom py-0 px-0");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "d-flex");
#nullable restore
#line 5 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
         if (!ActiveEdges.Any())
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "<div class=\"px-2\">\r\n                Default:\r\n            </div>\r\n            ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "px-1");
            __Blazor.GraphIt.web.Pages.EdgeOptions.TypeInference.CreateSfCheckBox_0(__builder, 7, 8, "Weighted", 9, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                OnDefWeightedChange

#line default
#line hidden
#nullable disable
            ), 10, "e-small", 11, 
#nullable restore
#line 11 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                           DefaultOptions.Weighted

#line default
#line hidden
#nullable disable
            , 12, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => DefaultOptions.Weighted = __value, DefaultOptions.Weighted)), 13, () => DefaultOptions.Weighted);
            __builder.AddMarkupContent(14, "\r\n                ");
            __Blazor.GraphIt.web.Pages.EdgeOptions.TypeInference.CreateSfCheckBox_1(__builder, 15, 16, "Directed", 17, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                OnDefDirectedChange

#line default
#line hidden
#nullable disable
            ), 18, "e-small", 19, 
#nullable restore
#line 12 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                           DefaultOptions.Directed

#line default
#line hidden
#nullable disable
            , 20, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => DefaultOptions.Directed = __value, DefaultOptions.Directed)), 21, () => DefaultOptions.Directed);
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "px-1");
            __builder.AddMarkupContent(25, "\r\n                Width ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(26);
            __builder.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                              DefaultOptions.EdgeWidth

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                            1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                  15

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                          1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "CssClass", "shortInput");
            __builder.AddAttribute(32, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                   ((e) => OnDefWidthChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n            ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "px-1");
            __builder.AddMarkupContent(36, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(37);
            __builder.AddAttribute(38, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                             DefaultOptions.EdgeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                    OnDefEdgeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n            ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "px-1");
            __builder.AddMarkupContent(43, "\r\n                Label ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(44);
            __builder.AddAttribute(45, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 22 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                             DefaultOptions.EdgeLabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(46, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                         OnDefEdgeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 24 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
        }
        else if (ActiveEdges.Count == 1)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(47, "<div class=\"px-2\">\r\n                Selected:\r\n            </div>\r\n            ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "px-1");
            __builder.AddMarkupContent(50, "\r\n                Width ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(51);
            __builder.AddAttribute(52, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                              ActiveEdges.ElementAt(0).Width

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(53, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                  1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(54, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                        15

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(55, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                                1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(56, "CssClass", "shortInput");
            __builder.AddAttribute(57, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 32 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                   ((e) => OnWidthChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n            ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "px-1");
            __builder.AddMarkupContent(61, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(62);
            __builder.AddAttribute(63, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                             ActiveEdges.ElementAt(0).EdgeColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                              OnEdgeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n            ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "px-1");
            __builder.AddMarkupContent(68, "\r\n                Label\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(69);
            __builder.AddAttribute(70, "CssClass", "shortInput");
            __builder.AddAttribute(71, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                              OnEdgeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(72, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                         ActiveEdges.ElementAt(0).Label

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(73, "\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(74);
            __builder.AddAttribute(75, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                       ActiveEdges.ElementAt(0).LabelColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(76, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                         OnEdgeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n            ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "px-1");
            __builder.OpenElement(80, "span");
            __builder.AddAttribute(81, "class", "px-2 btn-group");
            __builder.AddAttribute(82, "role", "group");
            __builder.OpenElement(83, "button");
            __builder.AddAttribute(84, "type", "button");
            __builder.AddAttribute(85, "class", "btn NavNone shadow-none py-0");
            __builder.AddAttribute(86, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                           () => OnCurve(0.1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(87, "-");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                    Curve\r\n                    ");
            __builder.OpenElement(89, "button");
            __builder.AddAttribute(90, "type", "button");
            __builder.AddAttribute(91, "class", "btn NavNone shadow-none py-0");
            __builder.AddAttribute(92, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                           () => OnCurve(-0.1)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(93, "+");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 49 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
             if (DefaultOptions.Weighted)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "px-1");
            __builder.AddMarkupContent(96, "\r\n                    Weight ");
            __Blazor.GraphIt.web.Pages.EdgeOptions.TypeInference.CreateSfNumericTextBox_2(__builder, 97, 98, 
#nullable restore
#line 52 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                     ActiveEdges.ElementAt(0).Weight

#line default
#line hidden
#nullable disable
            , 99, 
#nullable restore
#line 52 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                          1

#line default
#line hidden
#nullable disable
            , 100, 
#nullable restore
#line 52 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                           false

#line default
#line hidden
#nullable disable
            , 101, "shortInput", 102, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                                                                  ((e) => OnWeightChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(103, "<div class=\"px-2\">\r\n                Selected:\r\n            </div>\r\n            ");
            __builder.OpenElement(104, "div");
            __builder.AddAttribute(105, "class", "px-1");
            __builder.AddMarkupContent(106, "\r\n                Width ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfNumericTextBox<int?>>(107);
            __builder.AddAttribute(108, "Min", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 62 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                          1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(109, "Max", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 62 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                15

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(110, "Step", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<int?>(
#nullable restore
#line 62 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                        1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(111, "CssClass", "shortInput");
            __builder.AddAttribute(112, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 62 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                           ((e) => OnWidthChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\r\n            ");
            __builder.OpenElement(114, "div");
            __builder.AddAttribute(115, "class", "px-1");
            __builder.AddMarkupContent(116, "\r\n                Color ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(117);
            __builder.AddAttribute(118, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 65 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                  OnEdgeColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n            ");
            __builder.OpenElement(120, "div");
            __builder.AddAttribute(121, "class", "px-1");
            __builder.AddMarkupContent(122, "\r\n                Label\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfTextBox>(123);
            __builder.AddAttribute(124, "CssClass", "shortInput");
            __builder.AddAttribute(125, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ChangedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ChangedEventArgs>(this, 
#nullable restore
#line 69 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                              OnEdgeLabelChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(126, "\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(127);
            __builder.AddAttribute(128, "ValueChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.ColorPickerEventArgs>(this, 
#nullable restore
#line 70 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                            OnEdgeLabelColorChange

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n            ");
            __builder.OpenElement(130, "div");
            __builder.AddAttribute(131, "class", "px-1");
            __builder.AddMarkupContent(132, "\r\n                Curve\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(133);
            __builder.AddAttribute(134, "CssClass", "e-round");
            __builder.AddAttribute(135, "IconCss", "e-icons e-plus-icon");
            __builder.AddAttribute(136, "IsPrimary", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 74 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(137, "IsToggle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 74 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(138, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 74 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                                      (() => OnCurve(0.1))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(139, "\r\n                ");
            __builder.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(140);
            __builder.AddAttribute(141, "CssClass", "e-round");
            __builder.AddAttribute(142, "IconCss", "e-icons e-plus-icon");
            __builder.AddAttribute(143, "IsPrimary", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 75 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(144, "IsToggle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 75 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(145, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 75 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                                      (() => OnCurve(-0.1))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 77 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
             if (DefaultOptions.Weighted)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(146, "div");
            __builder.AddAttribute(147, "class", "px-1");
            __builder.AddMarkupContent(148, "\r\n                    Weight ");
            __Blazor.GraphIt.web.Pages.EdgeOptions.TypeInference.CreateSfNumericTextBox_3(__builder, 149, 150, 
#nullable restore
#line 80 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                 1

#line default
#line hidden
#nullable disable
            , 151, 
#nullable restore
#line 80 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                  false

#line default
#line hidden
#nullable disable
            , 152, "shortInput", 153, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 80 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
                                                                                                         ((e) => OnWeightChange(e))

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
#nullable restore
#line 82 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\EdgeOptions.razor"
             
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.GraphIt.web.Pages.EdgeOptions
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateSfCheckBox_0<TChecked>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::System.Object __arg1, int __seq2, global::System.String __arg2, int __seq3, TChecked __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TChecked> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TChecked>> __arg5)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Buttons.SfCheckBox<TChecked>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "onchange", __arg1);
        __builder.AddAttribute(__seq2, "CssClass", __arg2);
        __builder.AddAttribute(__seq3, "Checked", __arg3);
        __builder.AddAttribute(__seq4, "CheckedChanged", __arg4);
        __builder.AddAttribute(__seq5, "CheckedExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateSfCheckBox_1<TChecked>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::System.Object __arg1, int __seq2, global::System.String __arg2, int __seq3, TChecked __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TChecked> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TChecked>> __arg5)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Buttons.SfCheckBox<TChecked>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "onchange", __arg1);
        __builder.AddAttribute(__seq2, "CssClass", __arg2);
        __builder.AddAttribute(__seq3, "Checked", __arg3);
        __builder.AddAttribute(__seq4, "CheckedChanged", __arg4);
        __builder.AddAttribute(__seq5, "CheckedExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateSfNumericTextBox_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, TValue __arg1, int __seq2, global::System.Boolean __arg2, int __seq3, global::System.String __arg3, int __seq4, global::System.Object __arg4)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Inputs.SfNumericTextBox<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "Min", __arg1);
        __builder.AddAttribute(__seq2, "ShowSpinButton", __arg2);
        __builder.AddAttribute(__seq3, "CssClass", __arg3);
        __builder.AddAttribute(__seq4, "onchange", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateSfNumericTextBox_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::System.Boolean __arg1, int __seq2, global::System.String __arg2, int __seq3, global::System.Object __arg3)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Inputs.SfNumericTextBox<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Min", __arg0);
        __builder.AddAttribute(__seq1, "ShowSpinButton", __arg1);
        __builder.AddAttribute(__seq2, "CssClass", __arg2);
        __builder.AddAttribute(__seq3, "onchange", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591