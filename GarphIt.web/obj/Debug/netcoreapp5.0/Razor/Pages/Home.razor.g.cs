#pragma checksum "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2025e2bc302489008dc8b5104f350a2e7fed523d"
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
using GraphIt.models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.SplitButtons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
using Syncfusion.Blazor.Navigations.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\_Imports.razor"
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
            __builder.AddAttribute(1, "class", "NavNone dropdown border-right border-dark");
            __builder.AddMarkupContent(2, "<button class=\"btn shadow-none dropdown-toggle\" id=\"repre\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n        Representations\r\n    </button>\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "dropdown-menu");
            __builder.AddAttribute(5, "aria-labelledby", "repre");
            __builder.OpenElement(6, "a");
            __builder.AddAttribute(7, "class", "dropdown-item");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           OnMatrixClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Adjacency Matrix");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "class", "dropdown-item");
            __builder.AddAttribute(13, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           OnWeightMatrixClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(14, "Weighted Matrix");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n");
            __builder.OpenElement(16, "li");
            __builder.AddAttribute(17, "class", "NavNone dropdown border-right border-dark");
            __builder.AddMarkupContent(18, "<button class=\"btn shadow-none dropdown-toggle\" id=\"algos\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n        Algorithms\r\n    </button>\r\n    ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "dropdown-menu");
            __builder.AddAttribute(21, "aria-labelledby", "algos");
            __builder.OpenElement(22, "a");
            __builder.AddAttribute(23, "class", "dropdown-item");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           () => OnAlgoChanged(Algorithm.BFS)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "BFS");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.OpenElement(27, "a");
            __builder.AddAttribute(28, "class", "dropdown-item");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                           () => OnAlgoChanged(Algorithm.DFS)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(30, "DFS");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 22 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
 if (StartAlgorithm.Algorithm != Algorithm.None)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
     if (StartAlgorithm.StartNode == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(31, "<li class=\"navbar-text\">Choose Start Node</li>");
#nullable restore
#line 27 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
    }
    else if (RequiresEnd.Contains(StartAlgorithm.Algorithm) && StartAlgorithm.EndNode == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(32, "<li>Choose End Node</li>");
#nullable restore
#line 31 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(33, "<li><button class=\"btn\"><span class=\"oi oi-x\"></span></button></li>\r\n        ");
            __builder.AddMarkupContent(34, "<li><button class=\"btn\"><span class=\"oi oi-media-stop\"></span></button></li>\r\n        ");
            __builder.AddMarkupContent(35, "<li><button class=\"btn\"><span class=\"oi oi-media-skip-forward\"></span></button></li>\r\n        ");
            __builder.AddMarkupContent(36, "<li><button class=\"btn\"><span class=\"oi oi-media-step-forward\"></span></button></li>");
#nullable restore
#line 38 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
     
}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(37, "li");
            __builder.AddAttribute(38, "class", "NavNone p-2");
            __builder.AddAttribute(39, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "C:\Users\ahmki\OneDrive - University of Warwick\Warwick Studies\year 3\CS310-Final-Project\Project\GraphIt\GarphIt.web\Pages\Home.razor"
                                  OnSelectAll

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(40, "Select All");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
