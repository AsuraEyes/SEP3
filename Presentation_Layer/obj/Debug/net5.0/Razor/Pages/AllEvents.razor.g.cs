#pragma checksum "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7acbead11dfa5ef540d07d192b83af896bdf6bd0"
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
            __builder.AddMarkupContent(0, "<h2>AllEvents</h2>\n\n");
            __builder.OpenElement(1, "p");
            __builder.AddMarkupContent(2, "\n    Date:\n    ");
            __builder.OpenElement(3, "Select");
            __builder.AddAttribute(4, "class", "selectpicker");
            __builder.AddAttribute(5, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 15 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                                             arg => DateFilter(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(6, "option");
            __builder.AddAttribute(7, "value", 
#nullable restore
#line 16 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       filteringOptions[1]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(8, "-- All --");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n        ");
            __builder.OpenElement(10, "option");
            __builder.AddAttribute(11, "value", 
#nullable restore
#line 17 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       filteringOptions[0]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(12, "All Upcomming");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n    Category:\n    ");
            __builder.OpenElement(14, "Select");
            __builder.AddAttribute(15, "class", "selectpicker");
            __builder.AddAttribute(16, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 20 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                                             arg => CategoryFilter(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(17, "option");
            __builder.AddAttribute(18, "value", 
#nullable restore
#line 21 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       categoryOptions[0]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(19, "-- All --");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n        ");
            __builder.OpenElement(21, "option");
            __builder.AddAttribute(22, "value", 
#nullable restore
#line 22 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       categoryOptions[1]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(23, "Children");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\n        ");
            __builder.OpenElement(25, "option");
            __builder.AddAttribute(26, "value", 
#nullable restore
#line 23 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       categoryOptions[2]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(27, "Adults");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n        ");
            __builder.OpenElement(29, "option");
            __builder.AddAttribute(30, "value", 
#nullable restore
#line 24 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       categoryOptions[3]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(31, "Family");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\n    Available\n    ");
            __builder.OpenElement(33, "Select");
            __builder.AddAttribute(34, "class", "selectpicker");
            __builder.AddAttribute(35, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 27 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                                             arg => DateFilter(arg)

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(36, "option");
            __builder.AddAttribute(37, "value", 
#nullable restore
#line 28 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       filteringOptions[3]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(38, "-- All --");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\n        ");
            __builder.OpenElement(40, "option");
            __builder.AddAttribute(41, "value", 
#nullable restore
#line 29 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                       filteringOptions[2]

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(42, "Available");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\n\n\n");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "container");
#nullable restore
#line 35 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
     foreach (var item in EventsToShow)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                         () => NavigateToEvent(@item.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "class", "box");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "content");
            __builder.OpenElement(51, "h3");
            __builder.AddContent(52, 
#nullable restore
#line 39 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                     item.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\n                ");
            __builder.OpenElement(54, "p");
            __builder.AddContent(55, 
#nullable restore
#line 40 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                    item.StartTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\n                ");
            __builder.OpenElement(57, "p");
            __builder.AddContent(58, 
#nullable restore
#line 41 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
                    item.EndTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/AllEvents.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
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
