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
#line 2 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
using Presentation_Layer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
using Presentation_Layer.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
using System.Reflection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
using Microsoft.VisualBasic;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AllEvents")]
    public partial class AllEvents : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 77 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
       
    private IList<Event> EventsToShow = new List<Event>();
    private string Search;
    private int categoryId;
    private string filter ="all";
    private IList<int> categoryOptions = new List<int>() {0, 1, 2, 3};
    private IList<string> filteringOptions = new List<string>() {"byDate", "noDate", "byAvailability", "noAvailability", "byCategory", "noCategory"};

    protected override async Task OnInitializedAsync()
    {
        EventsToShow = await RestEvent.GetFilteredEventsAsync(filter, categoryId);
    }
    
    private async Task DateFilter(ChangeEventArgs args)
    {
        try
        {
            for (int i = 0; i < filteringOptions.Count; i++)
            {
                if (args.Value.ToString().Equals(filteringOptions[i]) && i%2 == 0)
                {
                    filter += filteringOptions[i];
                }
                else if (args.Value.ToString().Equals(filteringOptions[i]) && i%2 ==1)
                {
                    filter = filter.Replace(filteringOptions[i-1], "");
                }
            }
        }
        catch (Exception )
        {
        }
        EventsToShow = await RestEvent.GetFilteredEventsAsync(filter, categoryId);
    }

    private async Task CategoryFilter(ChangeEventArgs args)
    {
        try
        {
            if (int.Parse(args.Value.ToString()) != 0)
            {
                filter += filteringOptions[4];
                categoryId = int.Parse(args.Value.ToString());
            }
            else filter = filter.Replace(filteringOptions[4], string.Empty);
        }
        catch(Exception ){}
        EventsToShow = await RestEvent.GetFilteredEventsAsync(filter, categoryId);
    }

    private async Task NavigateToEvent(int id)
    {
        NavigationManager.NavigateTo($"EventInfo/{id}");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IEventService RestEvent { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
