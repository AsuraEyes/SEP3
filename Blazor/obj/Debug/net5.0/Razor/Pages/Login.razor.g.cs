#pragma checksum "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b928b3b4d1b132c1d1aeeb011c4d81a7894b236"
// <auto-generated/>
#pragma warning disable 1591
namespace SEP3_Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using SEP3_Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\_Imports.razor"
using SEP3_Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
using SEP3_Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
using AuthenticationStateProvider = SEP3_Blazor.Data.AuthenticationStateProvider;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "form-group");
                __builder2.AddMarkupContent(4, "<label>Username</label>\r\n            ");
                __builder2.OpenElement(5, "input");
                __builder2.AddAttribute(6, "type", "text");
                __builder2.AddAttribute(7, "placeholder", "username");
                __builder2.AddAttribute(8, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
                                                                   UserName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => UserName = __value, UserName));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(10, "\r\n        ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "form-group");
                __builder2.AddMarkupContent(13, "<label>Password</label>\r\n            ");
                __builder2.OpenElement(14, "input");
                __builder2.AddAttribute(15, "type", "password");
                __builder2.AddAttribute(16, "placeholder", "password");
                __builder2.AddAttribute(17, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
                                                                       Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Password = __value, Password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(19, "\r\n        ");
                __builder2.OpenElement(20, "div");
                __builder2.AddAttribute(21, "style", "color:red");
                __builder2.AddContent(22, 
#nullable restore
#line 20 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
                                errorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.OpenElement(24, "button");
                __builder2.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
                          PerformLogin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "class", "btn-dark");
                __builder2.AddContent(27, "LOGIN");
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(28, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(29, "h5");
                __builder2.AddContent(30, " Hello ");
                __builder2.AddContent(31, 
#nullable restore
#line 26 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
                    context.User.Identity.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(32, "! ");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(33, "\r\n    \r\n}");
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\Anca\RiderProjects\SEP3-Blazor\SEP3-Blazor\Pages\Login.razor"
       
    private string UserName;
    private string Password;
    private string errorMessage;

    public async Task PerformLogin()
    {
        errorMessage = "";
        try
        {
            ((AuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(UserName, Password);
            UserName = "";
            Password = "";
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
    }

    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AAuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591