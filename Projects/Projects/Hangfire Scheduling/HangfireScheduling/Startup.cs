using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HangfireScheduling
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Create Service
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseMemoryStorage());

            services.AddHangfireServer();

            //Call for the desired Job
            services.AddSingleton<IPrintJob, PrintJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("WebScrapping SanaRate!");
                });
            });

            //Call Hangfire Dashboard
            app.UseHangfireDashboard();

            //Initializes a new instance of the BackgroundJobClient class with the storage from a global configuration.
            backgroundJobClient.Enqueue(() => Console.WriteLine("Web_Scrapper SanaRate"));

            //Implement Job management with Cron commands
            recurringJobManager.AddOrUpdate(
                "Run every minute",
                () => serviceProvider.GetService<IPrintJob>().Print(),
                "*/15 * * * *"
                );
        }
    }
}
