#pragma checksum "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18f8bb6f144b35baf2c4089e2e6da26b11e040bc"
// <auto-generated/>
#pragma warning disable 1591
namespace Presentation_Layer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Presentation_Layer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\_Imports.razor"
using Presentation_Layer.Shared;

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
                __builder2.AddAttribute(3, "class", "remove_margin");
                __builder2.AddAttribute(4, "style", "color:red");
                __builder2.AddContent(5, 
#nullable restore
#line 7 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                                      errorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(6, "\r\n        ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "form-group remove_margin");
                __builder2.OpenElement(9, "input");
                __builder2.AddAttribute(10, "class", "form__input");
                __builder2.AddAttribute(11, "id", "username");
                __builder2.AddAttribute(12, "type", "text");
                __builder2.AddAttribute(13, "placeholder", "username");
                __builder2.AddAttribute(14, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 9 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                                                                                     username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => username = __value, username));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(16, "\r\n            ");
                __builder2.AddMarkupContent(17, "<label class=\"form__label\" for=\"username\">Username</label>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(18, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "class", "form-group remove_margin");
                __builder2.OpenElement(21, "input");
                __builder2.AddAttribute(22, "class", "form__input");
                __builder2.AddAttribute(23, "id", "password");
                __builder2.AddAttribute(24, "type", "password");
                __builder2.AddAttribute(25, "placeholder", "password");
                __builder2.AddAttribute(26, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                                                                                         password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => password = __value, password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n            ");
                __builder2.AddMarkupContent(29, "<label class=\"form__label\" for=\"password\">Password</label>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n\r\n\r\n        ");
                __builder2.OpenElement(31, "a");
                __builder2.AddAttribute(32, "class", "login_logout");
                __builder2.AddAttribute(33, "href", "");
                __builder2.AddAttribute(34, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                                  PerformLogin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(35, "<span class=\"oi oi-account-login\" aria-hidden=\"true\"></span>\r\n            Login\r\n        ");
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(36, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(37, "p");
                __builder2.AddAttribute(38, "class", "remove_margin");
                __builder2.AddContent(39, "Hello, ");
                __builder2.AddContent(40, 
#nullable restore
#line 26 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                         username

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(41, " !");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n        ");
                __builder2.OpenElement(43, "a");
                __builder2.AddAttribute(44, "class", "login_logout");
                __builder2.AddAttribute(45, "href", "");
                __builder2.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
                                                  PerformLogout

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(47, "<span class=\"oi oi-account-logout\" aria-hidden=\"true\"></span>\r\n            Log out\r\n        ");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "C:\Users\Maggie\RiderProjects\SEP3\Presentation_Layer\Pages\Login.razor"
       
    private string username;
    private string password;
    private string errorMessage;

    public async Task PerformLogin()
    {
        errorMessage = "";
        try
        {
            //((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
    }

    public async Task PerformLogout()
    {
        errorMessage = "";
        username = "";
        password = "";
        try
        {
            //((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
