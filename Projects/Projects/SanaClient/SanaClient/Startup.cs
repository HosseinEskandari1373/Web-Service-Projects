using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanaClient.Jobs.ConnectXrmAPI_Inset_RecurringDaily;
using SanaClient.Jobs.SanaAPI_Post_Recurring3H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanaClient
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
            /*
               * Add Hangfire services.
               * Configuration SQL Server
            */
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            //services.AddHangfireServer();

            //Call for the desired Job
            services.AddSingleton<ISanaAPI_Post_RecurringDaily, SanaAPI_Post_RecurringDaily>();
            //services.AddSingleton<IConnectXrmAPI_Inset_RecurringDaily, ConnectXrmAPI_Inset_RecurringDaily>();
            //services.AddSingleton<IConnectXrmAPI_InsertSRM_RecurringDaily, ConnectXrmAPI_InsertSRM_RecurringDaily>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseHangfireDashboard();

            //Implement Job management with Cron commands
            recurringJobManager.AddOrUpdate(
                "Run every day at 16 p.m",
                () => serviceProvider.GetService<ISanaAPI_Post_RecurringDaily>().Create(),
                "0 16 * * *",
                TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
                );

            //Implement Job management with Cron commands
            /* 
             * recurringJobManager.AddOrUpdate(
                 "Run every Day XRM",
                 () => serviceProvider.GetService<IConnectXrmAPI_Inset_RecurringDaily>().Insert(),
                 "15 12 * * *",
                 TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
                 );
            */

            //Implement Job management with Cron commands
            /*
             * recurringJobManager.AddOrUpdate(
                "Run every Day SRM",
                () => serviceProvider.GetService<IConnectXrmAPI_InsertSRM_RecurringDaily>().InsertSRM(),
                "30 12 * * *",
                TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
                );
            */
        }
    }
}
