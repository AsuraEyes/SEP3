#pragma checksum "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b235afbdce3a2be257eeb1f7d5052f8c3f2ea51a"
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
#line 2 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
using global::Data;

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
#nullable restore
#line 5 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
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
            __builder.AddMarkupContent(0, "<h1>BOOK & PLAY - CRUD demo</h1>\n\n");
            __builder.OpenElement(1, "h2");
            __builder.AddAttribute(2, "style", "color:red;");
            __builder.AddContent(3, 
#nullable restore
#line 11 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                        title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\n\nWelcome to your new bording games app.\n<br>\n\n    ");
            __builder.AddMarkupContent(5, "<h3 style=\"color:green\">Add Game</h3>\n\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(6);
            __builder.AddAttribute(7, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 18 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                      Game

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 18 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                            AddGameAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(10);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(12);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(13, "\n        ");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "form-group");
                __builder2.AddMarkupContent(16, "\n            Game part1:\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "type", "text");
                __builder2.AddAttribute(19, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                                Game.name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Game.name = __value, Game.name))));
                __builder2.AddAttribute(21, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Game.name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\n            part 2:\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(23);
                __builder2.AddAttribute(24, "type", "text");
                __builder2.AddAttribute(25, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                                Game.shortDescription

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Game.shortDescription = __value, Game.shortDescription))));
                __builder2.AddAttribute(27, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Game.shortDescription));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\n            ");
                __builder2.AddMarkupContent(29, "<button class=\"btn btn-outline-dark\" type=\"submit\">Create</button>");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 31 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
 if (GameToEdit != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(30, "<h3 style=\"color:green\">Edit Game</h3>\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(31);
            __builder.AddAttribute(32, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 34 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                      GameToEdit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(33, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 34 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                                  Save

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(35);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(37);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(38, "\n        ");
                __builder2.OpenElement(39, "div");
                __builder2.AddAttribute(40, "class", "form-group");
                __builder2.AddMarkupContent(41, "\n            Game part1:\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(42);
                __builder2.AddAttribute(43, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                    GameToEdit.name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(44, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => GameToEdit.name = __value, GameToEdit.name))));
                __builder2.AddAttribute(45, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => GameToEdit.name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\n            part 2:\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(47);
                __builder2.AddAttribute(48, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                    GameToEdit.shortDescription

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(49, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => GameToEdit.shortDescription = __value, GameToEdit.shortDescription))));
                __builder2.AddAttribute(50, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => GameToEdit.shortDescription));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(51, "\n            ");
                __builder2.AddMarkupContent(52, "<button class=\"btn btn-outline-dark\" type=\"submit\">Edit</button>");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 45 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(53, "<h3>Choose a Game to edit</h3>");
#nullable restore
#line 49 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(54, "<br>\n");
            __builder.AddMarkupContent(55, "<h3>Game List</h3>");
#nullable restore
#line 53 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
 if (GameList == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(56, "<p><em>Loading...</em></p>");
#nullable restore
#line 58 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
}
else if (!GameList.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(57, "<p><em>No Games exist. Please add some.</em></p>");
#nullable restore
#line 64 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(58, "table");
            __builder.AddAttribute(59, "class", "table");
            __builder.AddMarkupContent(60, @"<thead><tr><th>Click to replace title</th>
                <th>id</th>
                <th>name</th>
                <th>complexity</th>
                <th>timeEstimation</th>
                <th>minNumberOfPlayers</th>
                <th>maxNumberOfPlayers</th>
                <th>shorthescription</th>
                <th>neededEquipment</th>
                <th>minAge</th>
                <th>maxAge</th>
                <th>tutorial</th>
            <th>Remove</th>
            <th>Edit</th></tr></thead>
        ");
            __builder.OpenElement(61, "tbody");
#nullable restore
#line 88 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
         foreach (var item in GameList)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(62, "tr");
            __builder.OpenElement(63, "td");
            __builder.OpenElement(64, "button");
            __builder.AddAttribute(65, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 91 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                        () => ChangeTitle(item.id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(66, "<i class=\"oi oi-arrow-top\" style=\"color:red\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\n                ");
            __builder.OpenElement(68, "td");
            __builder.AddContent(69, 
#nullable restore
#line 94 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\n                ");
            __builder.OpenElement(71, "td");
            __builder.AddContent(72, 
#nullable restore
#line 95 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\n                ");
            __builder.OpenElement(74, "td");
            __builder.AddContent(75, 
#nullable restore
#line 96 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.complexity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\n                ");
            __builder.OpenElement(77, "td");
            __builder.AddContent(78, 
#nullable restore
#line 97 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.timeEstimation

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\n                ");
            __builder.OpenElement(80, "td");
            __builder.AddContent(81, 
#nullable restore
#line 98 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.minNumberOfPlayers

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\n                ");
            __builder.OpenElement(83, "td");
            __builder.AddContent(84, 
#nullable restore
#line 99 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.maxNumberOfPlayers

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\n                ");
            __builder.OpenElement(86, "td");
            __builder.AddContent(87, 
#nullable restore
#line 100 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.shortDescription

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\n                ");
            __builder.OpenElement(89, "td");
            __builder.AddContent(90, 
#nullable restore
#line 101 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.neededEquipment

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(91, "\n                ");
            __builder.OpenElement(92, "td");
            __builder.AddContent(93, 
#nullable restore
#line 102 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.minAge

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\n                ");
            __builder.OpenElement(95, "td");
            __builder.AddContent(96, 
#nullable restore
#line 103 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.maxAge

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\n                ");
            __builder.OpenElement(98, "td");
            __builder.AddContent(99, 
#nullable restore
#line 104 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                     item.tutorial

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\n                ");
            __builder.OpenElement(101, "td");
            __builder.OpenElement(102, "button");
            __builder.AddAttribute(103, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 106 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                        () => RemoveGameAsync(item.id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(104, "<i class=\"oi oi-trash\" style=\"color:red\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\n                ");
            __builder.OpenElement(106, "td");
            __builder.OpenElement(107, "button");
            __builder.AddAttribute(108, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 111 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
                                        () => GameToEdit = GameList.FirstOrDefault(t => t.id == item.id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(109, "<i class=\"oi oi-pencil\" style=\"color:#1b6ec2\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 116 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 119 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(110, "Login");
            __builder.AddContent(111, "Login");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 124 "/Users/shadow_asura/Documents/VIA/3RD SEMESTER/SEP3/Presentation_Layer/Pages/Index.razor"
 
    private string title = "Hello World";
    private Game Game = new Game();
    private Game GameToEdit;
    private IList<Game> GameList;

    protected override async Task OnInitializedAsync()
    {
        GameList = await SoapGame.GetGamesAsync();
        GameToEdit = null;
    }
    
    public async Task AddGameAsync()
    {
        await SoapGame.AddGameAsync(Game);
        await OnInitializedAsync();
    }

    public async Task RemoveGameAsync(int id)
    {
        Game GameToRemove = GameList.First(t => t.id == id);
        await SoapGame.RemoveGameAsync(GameToRemove);
        await OnInitializedAsync();
    }

    public async Task ChangeTitle(int id)
    {
        Game GameToTittle = await SoapGame.GetGameAsync(id);
        title = GameToTittle.name;

    }
    
    public async Task Save()
    {
        await SoapGame.UpdateGameAsync(GameToEdit);
        GameToEdit = null;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISOAPGame SoapGame { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
