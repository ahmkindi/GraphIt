#pragma checksum "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "881cc26f5ef13da319b2bf88aa22a87bef0d8341"
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
    public partial class NodeCircle : NodeCircleBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
 if (ActiveNode != null && Node.NodeId == ActiveNode.NodeId)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "g");
            __builder.AddAttribute(2, "class", "pointer");
            __builder.AddAttribute(3, "id", 
#nullable restore
#line 6 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
            ActiveNode.NodeId

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "onmousedown", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     OnMouseDown

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "circle");
            __builder.AddAttribute(7, "cx", 
#nullable restore
#line 8 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     ActiveNode.Xaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(8, "cy", 
#nullable restore
#line 9 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     ActiveNode.Yaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(9, "r", 
#nullable restore
#line 10 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                    ActiveNode.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(10, "stroke", "black");
            __builder.AddAttribute(11, "stroke-width", "2");
            __builder.AddAttribute(12, "fill", 
#nullable restore
#line 13 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                       ActiveNode.NodeColor

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "text");
            __builder.AddAttribute(15, "text-anchor", "middle");
            __builder.AddAttribute(16, "fill", 
#nullable restore
#line 15 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     ActiveNode.LabelColor

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "font-size", 
#nullable restore
#line 16 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                           ActiveNode.Radius/2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(18, "font-family", "Verdana");
            __builder.AddAttribute(19, "x", 
#nullable restore
#line 18 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                  ActiveNode.Xaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(20, "y", 
#nullable restore
#line 19 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                  ActiveNode.Yaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(21, "\r\n");
#nullable restore
#line 20 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
             if (ActiveNode.Label == null)
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddContent(22, 
#nullable restore
#line 22 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                 ActiveNode.NodeId

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 22 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                                  
            }
            else
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddContent(23, 
#nullable restore
#line 26 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                 ActiveNode.Label

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 26 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                                 
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n    ");
            __builder.OpenElement(27, "rect");
            __builder.AddAttribute(28, "x", 
#nullable restore
#line 30 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
               ActiveNode.Xaxis-ActiveNode.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(29, "y", 
#nullable restore
#line 31 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
               ActiveNode.Yaxis-ActiveNode.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(30, "width", 
#nullable restore
#line 32 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                   ActiveNode.Radius*2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(31, "height", 
#nullable restore
#line 33 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                    ActiveNode.Radius*2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(32, "stroke", "black");
            __builder.AddAttribute(33, "stroke-dasharray", "5,5");
            __builder.AddAttribute(34, "fill", "none");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n");
#nullable restore
#line 37 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(36, "    ");
            __builder.OpenElement(37, "g");
            __builder.AddAttribute(38, "class", "pointer");
            __builder.AddAttribute(39, "id", 
#nullable restore
#line 41 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
            Node.NodeId

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(40, "onmousedown", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 42 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     OnMouseDown

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(41, "\r\n        ");
            __builder.OpenElement(42, "circle");
            __builder.AddAttribute(43, "cx", 
#nullable restore
#line 43 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     Node.Xaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(44, "cy", 
#nullable restore
#line 44 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     Node.Yaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(45, "r", 
#nullable restore
#line 45 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                    Node.Radius

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(46, "stroke", "black");
            __builder.AddAttribute(47, "stroke-width", "2");
            __builder.AddAttribute(48, "fill", 
#nullable restore
#line 48 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                       Node.NodeColor

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n        ");
            __builder.OpenElement(50, "text");
            __builder.AddAttribute(51, "text-anchor", "middle");
            __builder.AddAttribute(52, "fill", 
#nullable restore
#line 50 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                     Node.LabelColor

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(53, "font-size", 
#nullable restore
#line 51 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                           Node.Radius/2

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(54, "font-family", "Verdana");
            __builder.AddAttribute(55, "x", 
#nullable restore
#line 53 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                  Node.Xaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(56, "y", 
#nullable restore
#line 54 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                  Node.Yaxis

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(57, "\r\n");
#nullable restore
#line 55 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
             if (Node.Label == null)
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddContent(58, 
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                 Node.NodeId

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 57 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                            
            }
            else
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddContent(59, 
#nullable restore
#line 61 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                 Node.Label

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 61 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
                           
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(60, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n");
#nullable restore
#line 65 "C:\Users\ahmki\source\repos\GarphIt\GarphIt.web\Pages\NodeCircle.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
