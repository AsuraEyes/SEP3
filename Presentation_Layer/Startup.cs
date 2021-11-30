using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Layer.Authentication;
using Presentation_Layer.Data;
using SEP3_Blazor.Data;

namespace Presentation_Layer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<IEventGameListService, EventGameListService>();
            services.AddScoped<IGameListService, GameListService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IEventOrganizerService, EventOrganizerService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Organizer", a => a.RequireAuthenticatedUser().RequireClaim("Level", "3"));
                options.AddPolicy("Player", a => a.RequireAuthenticatedUser().RequireClaim("Level", "2"));
                options.AddPolicy("Administrator", a => a.RequireAuthenticatedUser().RequireClaim("Level", "1"));
                options.AddPolicy("PlayerOrOrganizer", a => 
                    a.RequireAuthenticatedUser().RequireAssertion(context =>
                    {
                        Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
                        if (levelClaim == null) return false;
                        //2 (Player), 3 (Organizer)
                        return int.Parse(levelClaim.Value) >= 2;
                    }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}