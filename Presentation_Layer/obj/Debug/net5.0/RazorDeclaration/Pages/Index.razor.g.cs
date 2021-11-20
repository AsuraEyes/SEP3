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
#line 1 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Presentation_Layer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/_Imports.razor"
using Presentation_Layer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
using Presentation_Layer.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
using Presentation_Layer.Models;

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
#line 127 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
 
    private string title = "Hello World";
    private Game Game = new Game();
    private Game GameToEdit;
    private IList<Game> GameList;
    
    /*protected override async Task OnInitializedAsync()
    {
        GameList = await SoapGame.GetGamesAsync();
        GameToEdit = null;
    }
    */
    
    public async Task AddGameAsync()
    {
        await SoapGame.AddGameAsync(Game);
        await OnInitializedAsync();
    }

    public async Task RemoveGameAsync(int id)
    {
        Game GameToRemove = GameList.First(t => t.Id == id);
        await SoapGame.RemoveGameAsync(GameToRemove);
        await OnInitializedAsync();
    }

    public async Task ChangeTitle(int id)
    {
        Game GameToTittle = await SoapGame.GetGameAsync(id);
        title = GameToTittle.Name;

    }
    
    public async Task Save()
    {
        await SoapGame.UpdateGameAsync(GameToEdit);
        GameToEdit = null;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IGameService SoapGame { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
