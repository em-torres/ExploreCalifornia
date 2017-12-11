using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ExploreCalifornia.Models;

namespace ExploreCalifornia
{
    public class Startup
    {

        private readonly IConfigurationRoot configuration;  //Variable for the configurations

        // This method gets called by the runtime. It's used to call the Environment variables and configurations on startup of application
        public Startup(IHostingEnvironment env)
        {
            // Creating custom configurations
            configuration = new ConfigurationBuilder()
                                  .AddEnvironmentVariables()
                                  .AddJsonFile(env.ContentRootPath + "/config.json")
                                  .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                                  .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // A transient for the application to recognize the FormattingService Model to format the Views
            services.AddTransient<FormattingService>();

            // A transient to be used as a instance configuration every time it's requested for the FeaturesToggle Class
            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions = configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });

            // Adding the MVC framework to the configuration of the app.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, FeatureToggles features)
        {
            loggerFactory.AddConsole();

            app.UseExceptionHandler("/error.html");

            // Evaluating with the custom configurations files and environment variables
            if (features.EnableDeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) => 
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("ERROR!");

                await next();
            });

            // Calling the MVC Framework
            app.UseMvc(routes => 
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id:int?}");
            });

            // Using the `Microsoft.AspNetCore.StaticFiles` to serve static files
            app.UseFileServer();
        }
    }
}
