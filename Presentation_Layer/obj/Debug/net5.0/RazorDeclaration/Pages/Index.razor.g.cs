// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Presentation_Layer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Presentation_Layer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\_Imports.razor"
using Presentation_Layer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\Pages\Index.razor"
using global::Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\Pages\Index.razor"
using Presentation_Layer.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\Pages\Index.razor"
using Presentation_Layer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\Pages\Index.razor"
using SEP3_Blazor.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 108 "C:\Users\em_du\Documents\SEP3\Presentation_Layer\Pages\Index.razor"
 
    private string title = "Hello World";
    private message message = new message();
    private message messageToEdit;
    private IList<message> messageList;

    protected override async Task OnInitializedAsync()
    {
        messageList = await SoapMessage.GetMessagesAsync();
        messageToEdit = null;
        message.body = "";
        message.name = "";
    }
    
    public async Task AddMessageAsync()
    {
        await SoapMessage.AddMessageAsync(message);
        await OnInitializedAsync();
       
    }

    public async Task RemoveMessageAsync(int id)
    {
        message messageToRemove = messageList.First(t => t.id == id);
        await SoapMessage.RemoveMessageAsync(messageToRemove);
        await OnInitializedAsync();
    }

    public async Task ChangeTitle(int id)
    {
        message messageToTittle = await SoapMessage.GetMessageAsync(id);
        title = messageToTittle.name + " " + messageToTittle.body;

    }
    
    public async Task Save()
    {
        await SoapMessage.UpdateMessageAsync(messageToEdit);
        messageToEdit = null;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISOAPMessage SoapMessage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591