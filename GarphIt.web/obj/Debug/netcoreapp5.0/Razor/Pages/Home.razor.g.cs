#pragma checksum "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76d052bc09ca0d2d04a922ac6100ac8357e47bd7"
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
    public partial class Home : HomeBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "li");
            __builder.AddAttribute(1, "class", "NavNone p-2 border-right border-dark");
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                           OnSelectAll

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(3, "Select All");
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.OpenElement(5, "li");
            __builder.AddAttribute(6, "class", "NavNone dropdown border-right border-dark");
            __builder.AddMarkupContent(7, "<button class=\"btn shadow-none dropdown-toggle\" id=\"repre\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n        Representations\r\n    </button>\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "dropdown-menu");
            __builder.AddAttribute(10, "aria-labelledby", "repre");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "class", "dropdown-item");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           OnMatrixClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(14, "Adjacency Matrix");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.OpenElement(16, "a");
            __builder.AddAttribute(17, "class", "dropdown-item");
            __builder.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           OnWeightMatrixClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(19, "Weighted Matrix");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n");
            __builder.OpenElement(21, "li");
            __builder.AddAttribute(22, "class", "NavNone dropdown border-right border-dark");
            __builder.AddMarkupContent(23, "<button class=\"btn shadow-none dropdown-toggle\" id=\"algos\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n        Algorithms\r\n    </button>\r\n    ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "dropdown-menu");
            __builder.AddAttribute(26, "aria-labelledby", "algos");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "class", "btn dropdown-item");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.BFS)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "disabled", 
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                   IsDisabled[(int)Algorithm.BFS]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(31, "BFS");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n        ");
            __builder.OpenElement(33, "button");
            __builder.AddAttribute(34, "class", "btn dropdown-item");
            __builder.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.DFS)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(36, "disabled", 
#nullable restore
#line 19 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                   IsDisabled[(int)Algorithm.DFS]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(37, "DFS");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n        ");
            __builder.OpenElement(39, "button");
            __builder.AddAttribute(40, "class", "btn dropdown-item");
            __builder.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.Kruskal)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "disabled", 
#nullable restore
#line 20 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                       IsDisabled[(int)Algorithm.Kruskal]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(43, "Kruskals MST");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n        ");
            __builder.OpenElement(45, "button");
            __builder.AddAttribute(46, "class", "btn dropdown-item");
            __builder.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.Dijkstra)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "disabled", 
#nullable restore
#line 21 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                        IsDisabled[(int)Algorithm.Dijkstra]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(49, "Dijkstras Single Source");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n        ");
            __builder.OpenElement(51, "button");
            __builder.AddAttribute(52, "class", "btn dropdown-item");
            __builder.AddAttribute(53, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.DijkstraPath)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(54, "disabled", 
#nullable restore
#line 22 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                            IsDisabled[(int)Algorithm.DijkstraPath]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(55, "Dijkstras Shortest Path");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n        ");
            __builder.OpenElement(57, "button");
            __builder.AddAttribute(58, "class", "btn dropdown-item");
            __builder.AddAttribute(59, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.MaxFlow)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(60, "disabled", 
#nullable restore
#line 23 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                       IsDisabled[(int)Algorithm.MaxFlow]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(61, "Max-flow");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n        ");
            __builder.OpenElement(63, "button");
            __builder.AddAttribute(64, "class", "btn dropdown-item");
            __builder.AddAttribute(65, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.Articulation)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(66, "disabled", 
#nullable restore
#line 24 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                            IsDisabled[(int)Algorithm.Articulation]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(67, "Articulation Points");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n        ");
            __builder.OpenElement(69, "button");
            __builder.AddAttribute(70, "class", "btn dropdown-item");
            __builder.AddAttribute(71, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                    () => OnAlgoChanged(Algorithm.Degree)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(72, "disabled", 
#nullable restore
#line 25 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                      IsDisabled[(int)Algorithm.Degree]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(73, "Degree of Vertices");
            __builder.CloseElement();
#nullable restore
#line 26 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
         if (DefaultOptions.Directed)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(74, "button");
            __builder.AddAttribute(75, "class", "btn dropdown-item");
            __builder.AddAttribute(76, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                        () => GetDegreePref = true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(77, "disabled", 
#nullable restore
#line 28 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                               IsDisabled[(int)Algorithm.DegreeCentrality]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(78, "Degree Centrality");
            __builder.CloseElement();
#nullable restore
#line 29 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(79, "button");
            __builder.AddAttribute(80, "class", "btn dropdown-item");
            __builder.AddAttribute(81, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                        () => OnAlgoChanged(Algorithm.DegreeCentrality)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(82, "disabled", 
#nullable restore
#line 32 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                                    IsDisabled[(int)Algorithm.DegreeCentrality]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(83, "Degree Centrality");
            __builder.CloseElement();
#nullable restore
#line 33 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 37 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
 if (StartAlgorithm.Algorithm != Algorithm.None)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
     if (StartAlgorithm.Type != AlgorithmType.NoInput && StartAlgorithm.StartNode == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(84, "<li class=\"navbar-text font-weight-bold px-2\">Choose Start Node</li>");
#nullable restore
#line 42 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
    }
    else if (StartAlgorithm.EndNode == null && StartAlgorithm.Type == AlgorithmType.TwoInput)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(85, "<li class=\"navbar-text font-weight-bold px-2\">Choose End Node</li>");
#nullable restore
#line 46 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
         if (!Animate)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(86, "li");
            __builder.AddAttribute(87, "class", "NavNone p-2");
            __builder.AddAttribute(88, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                              () => Animate = true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(89, "Animate");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n            ");
            __builder.OpenElement(91, "li");
            __builder.AddAttribute(92, "class", "NavNone p-2");
            __builder.AddAttribute(93, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                              async () => { StartAlgorithm.Clear = true; await StartAlgorithmChanged.InvokeAsync(StartAlgorithm); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(94, "Clear");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n            ");
            __builder.OpenElement(96, "li");
            __builder.AddAttribute(97, "class", "navbar-text font-weight-bold alert-success");
            __builder.AddContent(98, 
#nullable restore
#line 53 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                    StartAlgorithm.Output

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(99, "<li><button class=\"btn\"><span class=\"oi oi-media-stop\"></span></button></li>\r\n            ");
            __builder.AddMarkupContent(100, "<li><button class=\"btn\"><span class=\"oi oi-media-skip-forward\"></span></button></li>\r\n            ");
            __builder.AddMarkupContent(101, "<li><button class=\"btn\"><span class=\"oi oi-media-step-forward\"></span></button></li>\r\n            ");
            __builder.OpenElement(102, "li");
            __builder.OpenElement(103, "button");
            __builder.AddAttribute(104, "class", "btn");
            __builder.AddAttribute(105, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 60 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                              () => Animate = false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(106, "<span class=\"oi oi-x\"></span>");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 61 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
 if (GetDegreePref)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(107);
            __builder.AddAttribute(108, "Width", "300px");
            __builder.AddAttribute(109, "IsModal", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 67 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                     true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(110, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(111);
                __builder2.AddAttribute(112, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(113, "div");
                    __builder3.AddAttribute(114, "class", "text-center");
                    __builder3.AddMarkupContent(115, "<div class=\"row m-3 border-bottom border-dark\">\r\n                        How do you specify the importance of a Node?\r\n                    </div>\r\n                    ");
                    __builder3.OpenElement(116, "div");
                    __builder3.AddAttribute(117, "class", "d-flex align-items-baseline");
                    __builder3.OpenElement(118, "button");
                    __builder3.AddAttribute(119, "class", "btn btn-outline-success shadow-none btn-sm");
                    __builder3.AddAttribute(120, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 76 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                          async () => { await OnAlgoChanged(Algorithm.InDegreeCentrality); GetDegreePref = false; }

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(121, "In-Degree");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(122, "\r\n                        ");
                    __builder3.OpenElement(123, "button");
                    __builder3.AddAttribute(124, "class", "btn btn-outline-success shadow-none btn-sm");
                    __builder3.AddAttribute(125, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 78 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                          async () => { await OnAlgoChanged(Algorithm.OutDegreeCentrality); GetDegreePref = false; }

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(126, "Out-Degree");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(127, "\r\n                        ");
                    __builder3.OpenElement(128, "button");
                    __builder3.AddAttribute(129, "class", "btn btn-outline-success shadow-none btn-sm");
                    __builder3.AddAttribute(130, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 80 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                          async () => { await OnAlgoChanged(Algorithm.DegreeCentrality); GetDegreePref = false; }

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(131, "Both");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(132, "\r\n                        ");
                    __builder3.OpenElement(133, "button");
                    __builder3.AddAttribute(134, "class", "ml-auto btn btn-outline-dark shadow-none btn-sm");
                    __builder3.AddAttribute(135, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 81 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                                                                                  () => GetDegreePref = false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(136, "cancel");
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
#line 87 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
