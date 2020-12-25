#pragma checksum "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "738a5f9c902dfafbb502e70bb7dd82e89a44fb83"
// <auto-generated/>
#pragma warning disable 1591
namespace EmployeeManagement.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using EmployeeManagement.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using EmployeeManagement.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using Ergis.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\_Imports.razor"
using EmployeeManagement.Models;

#line default
#line hidden
#nullable disable
    public partial class EmployeeListItem : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "card m-3");
            __builder.AddAttribute(2, "style", "min-width: 18rem; max-width: 30.5%;");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "card-header");
            __builder.OpenElement(5, "h3");
            __builder.OpenElement(6, "input");
            __builder.AddAttribute(7, "type", "checkbox");
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 5 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                              CheckboxChanged

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.AddContent(10, 
#nullable restore
#line 6 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
             Employee.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(11, " ");
            __builder.AddContent(12, 
#nullable restore
#line 6 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                 Employee.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n\r\n    ");
            __builder.OpenElement(14, "img");
            __builder.AddAttribute(15, "class", "card-img-top imageThumbnail");
            __builder.AddAttribute(16, "src", 
#nullable restore
#line 10 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                                   Employee.Photo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 12 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
     if (DisplayFooter)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "card-footer text-center");
            __builder.OpenElement(19, "a");
            __builder.AddAttribute(20, "href", "/employee/" + (
#nullable restore
#line 15 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                Employee.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "class", "btn btn-sm btn-primary m-1");
            __builder.AddContent(22, " View ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.OpenElement(24, "a");
            __builder.AddAttribute(25, "href", "/employee/" + (
#nullable restore
#line 16 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                Employee.Id

#line default
#line hidden
#nullable disable
            ) + "/edit");
            __builder.AddAttribute(26, "class", "btn btn-sm btn-secondary m-1");
            __builder.AddContent(27, " Edit ");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n            ");
            __builder.OpenElement(29, "button");
            __builder.AddAttribute(30, "class", "btn btn-sm btn-danger m-1");
            __builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                                                                OnDeleteClick

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(32, " Delete ");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 19 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\r\n");
            __builder.OpenComponent<Ergis.Components.ConfirmDialog>(34);
            __builder.AddAttribute(35, "Title", "Confirm");
            __builder.AddAttribute(36, "Message", "Are you sure you want to delete this employee?");
            __builder.AddAttribute(37, "ConfirmBtn", "Yes");
            __builder.AddAttribute(38, "CancelBtn", "No");
            __builder.AddAttribute(39, "ConfirmCallback", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 29 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
                     OnDialogConfirm

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(40, (__value) => {
#nullable restore
#line 24 "C:\Users\user\source\repos\EmployeeManagement.Blazor\EmployeeManagement.Web\Pages\EmployeeListItem.razor"
          ConfirmModal = (Ergis.Components.ConfirmDialog)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591