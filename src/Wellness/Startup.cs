using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using Wellness.Models;
using Wellness.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Wellness
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public static string connectionString;

        public Startup(IHostingEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(appEnv.ContentRootPath)
              .AddJsonFile("appsettings.json")
              .AddEnvironmentVariables();
            
            Configuration = builder.Build();

            connectionString = $"{Configuration["ConnectionString"]}";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            //config.Filters.Add(new RequireHttpsAttribute());

            services.AddIdentity<WellnessUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                /*
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }

                        return Task.FromResult(0);
                    }
                };*/
            })
            .AddEntityFrameworkStores<WellnessContext>();
            
            services.AddLogging();

            services.AddDbContext<WellnessContext>(options =>
                options.UseSqlite("Data Source=.\\data.sqlite"));

            services.AddScoped<IWellnessRepository, WellnessRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment enviroment)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            Mapper.Initialize(config =>
            {
                config.CreateMap<Team, TeamViewModel>().ReverseMap();
                config.CreateMap<WellnessUser, SelfViewModel>().ReverseMap();
                config.CreateMap<WellnessUserMetric, MetricViewModel>().ReverseMap();
            });

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });
        }
    }
}
