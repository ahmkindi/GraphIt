#pragma checksum "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c48a46852811e4f5d91d36b0a6cf69e6446c6d4"
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
#line 1 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using GraphIt.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using GraphIt.web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using GraphIt.web.Pages.Design;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using GraphIt.models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.SplitButtons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using BlazorPro.BlazorSize;

#line default
#line hidden
#nullable disable
    public partial class File : FileBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "li");
            __builder.AddAttribute(1, "class", "NavNone dropdown border-right border-dark");
            __builder.AddMarkupContent(2, "<button class=\"btn shadow-none dropdown-toggle\" id=\"saveas\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\"><span class=\"oi oi-share-boxed pr-1\"></span>Export As\r\n    </button>\r\n\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "dropdown-menu");
            __builder.AddAttribute(5, "aria-labelledby", "saveas");
            __builder.OpenElement(6, "a");
            __builder.AddAttribute(7, "class", "dropdown-item");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                           () => SaveSVGFile(true)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "screen view SVG");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "class", "dropdown-item");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                           () => SaveSVGFile(false)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(14, "full view SVG");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        <div class=\"dropdown-divider\"></div>\r\n        ");
            __builder.OpenElement(16, "a");
            __builder.AddAttribute(17, "class", "dropdown-item");
            __builder.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                           SaveGraphItFile

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(19, "Graph File");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
            __builder.OpenElement(21, "li");
            __builder.AddAttribute(22, "class", "NavNone p-2 border-right border-dark");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                           (() => OpenPreference = true)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(24, "<span class=\"pr-1 oi oi-envelope-open\"></span>Open");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n");
            __builder.OpenElement(26, "li");
            __builder.AddAttribute(27, "class", "NavNone p-2");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                  (() => NewGraphCheck = true)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(29, "<span class=\"pr-1 oi oi-reload\"></span>New");
            __builder.CloseElement();
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
 if (ErrorOpening)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(30);
            __builder.AddAttribute(31, "Width", "300px");
            __builder.AddAttribute(32, "IsModal", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 20 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(34);
                __builder2.AddAttribute(35, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(36, "div");
                    __builder3.AddAttribute(37, "class", "text-center");
                    __builder3.AddMarkupContent(38, "<div class=\"row m-3 border-bottom border-dark\">\r\n                        Oops, I couldn\'t read the file you chose\r\n                    </div>\r\n                    ");
                    __builder3.OpenElement(39, "button");
                    __builder3.AddAttribute(40, "class", "btn btn-outline-dark shadow-none btn-sm");
                    __builder3.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                                                      (() => ErrorOpening = false)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddMarkupContent(42, "\r\n                        OK\r\n                    ");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 34 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
 if (OpenPreference)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(43);
            __builder.AddAttribute(44, "Width", "300px");
            __builder.AddAttribute(45, "IsModal", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 37 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                 true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(46, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(47);
                __builder2.AddAttribute(48, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(49, "div");
                    __builder3.AddAttribute(50, "class", "text-center");
                    __builder3.AddMarkupContent(51, "<div class=\"row m-3 border-bottom border-dark\">\r\n                    overwrite the current graph? or open it with the current graph?\r\n                </div>\r\n                ");
                    __builder3.OpenElement(52, "div");
                    __builder3.AddAttribute(53, "class", "d-flex align-items-baseline");
                    __builder3.AddMarkupContent(54, "<label for=\"FileUpload2\" class=\"btn btn-outline-success shadow-none btn-sm pointer\">\r\n                        Together\r\n                    </label>\r\n                    ");
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputFile>(55);
                    __builder3.AddAttribute(56, "id", "FileUpload2");
                    __builder3.AddAttribute(57, "OnChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>(this, 
#nullable restore
#line 48 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                          (e) => OpenGraphItFile(e, false)

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(58, "accept", ".phanatic");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(59, "\r\n                    ");
                    __builder3.AddMarkupContent(60, "<label for=\"FileUpload\" class=\"btn btn-outline-danger shadow-none btn-sm pointer\">\r\n                        Overwrite\r\n                    </label>\r\n                    ");
                    __builder3.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputFile>(61);
                    __builder3.AddAttribute(62, "id", "FileUpload");
                    __builder3.AddAttribute(63, "OnChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                         (e) => OpenGraphItFile(e, true)

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(64, "accept", ".phanatic");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(65, "\r\n                    ");
                    __builder3.OpenElement(66, "button");
                    __builder3.AddAttribute(67, "class", "ml-auto btn btn-outline-dark shadow-none btn-sm");
                    __builder3.AddAttribute(68, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 53 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                                                              (() => OpenPreference = false)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddMarkupContent(69, "\r\n                        Cancel\r\n                    ");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 61 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
 if (NewGraphCheck)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(70);
            __builder.AddAttribute(71, "Width", "300px");
            __builder.AddAttribute(72, "IsModal", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 64 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(73, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(74);
                __builder2.AddAttribute(75, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(76, "div");
                    __builder3.AddAttribute(77, "class", "text-center");
                    __builder3.AddMarkupContent(78, "<div class=\"row m-3 border-bottom border-dark\">\r\n                        Are you sure you want to restart?\r\n                    </div>\r\n                    ");
                    __builder3.OpenElement(79, "div");
                    __builder3.AddAttribute(80, "class", "d-flex align-items-baseline");
                    __builder3.OpenElement(81, "button");
                    __builder3.AddAttribute(82, "class", "btn btn-outline-success shadow-none btn-sm");
                    __builder3.AddAttribute(83, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 72 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                                                             SaveGraphItFile

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(84, "Save");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(85, "\r\n                        ");
                    __builder3.OpenElement(86, "button");
                    __builder3.AddAttribute(87, "class", "btn btn-outline-danger shadow-none btn-sm");
                    __builder3.AddAttribute(88, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 73 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                                                            () => UriHelper.NavigateTo(UriHelper.Uri, forceLoad: true)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(89, "New");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(90, "\r\n                        ");
                    __builder3.OpenElement(91, "button");
                    __builder3.AddAttribute(92, "class", "ml-auto btn btn-outline-dark shadow-none btn-sm");
                    __builder3.AddAttribute(93, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 74 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
                                                                                                  (() => NewGraphCheck = false)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(94, "Cancel");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 80 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\File.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
