# .NET HtmlAgilityPack
> The goal is to create a service for managing and scheduling various jobs. In this project, a service has been created by the Hangfire library so that we can apply the desired scheduling for jobs through Cron commands, and then it can be managed and monitored in the dashboard.
<hr>

## Technologies
##### Asp.Net Web Application
##### Hangfire
##### Hangfire.MemoryStorage

## Table of content

* [Job Scheduling with Hangfire](#job-scheduling-with-hangfire)
* [Create Service Hangfire](#create-service)
* [Build jobs and Manage and Schedule those Jobs](#create-job)
* [Job Management Created](#job-management-created)
* [Sources](#sources)

## <a name="job-scheduling-with-hangfire"></a>Job Scheduling with Hangfire
* Add the following frameworks to the project:
##### Hangfire.Core
##### Hangfire.AspNetCore
##### Hangfire.MemoryStorage
##### HtmlAgilityPack
##### Fizzler.Systems.HtmlAgilityPack
You can use NuGet to add this framework.

* Add the follwing namespaces to your class file:
##### using Hangfire;
##### using Hangfire.MemoryStorage;

---
## <a name="create-service"></a>Create Service Hangfire
* First we need to create the Hangfire service in Startup. For this purpose, we use the following code snippet:
            
            `// This method gets called by the runtime. Use this method to add services to the container.
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
        }`
---              
## <a name="create-job"></a>Build jobs and Manage and Schedule those Jobs
* For this purpose, first define a class and write the desired program in that class, and then create the interface of that class and use it in Startup.
* Example:

        `public class PrintJob : IPrintJob
    {
        //WebScrapper SanaRate
        public void Print()
        {
            var url = "https://fxmarketrate.cbi.ir/";

            var Client = new WebClient();
            var html = Client.DownloadString(url);

            var document = new HtmlDocument();

            //Load the Html Page in document
            document.LoadHtml(html);

            //Gets the root node of the document
            HtmlNodeCollection result = document.DocumentNode.SelectNodes(".//*[@id='MainContent_ViewCashChequeRates_divCash']/div[2]/*[@class='table table-hover table-bordered table-blueheader table-responsive']");

            var innerText = result.Select(node => node.InnerText);
            File.AppendAllLines(@"../Sana_Rate.txt", innerText);
        }
    }`
            
---
## <a name="job-management-created"></a>Job Management Created
* Now you need to call the job and schedule it with Cron commands.
* First, call Job by the following command: Write this command in the ConfigureServices method.

            `//Call for the desired Job
            services.AddSingleton<IPrintJob, PrintJob>();`

* Finally, manage and schedule it using the Cron commands and the following code:
            `public void Configure(
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
        }`
        
---
## <a name="sources"></a>Sources
https://www.hangfire.io/features.html

https://codingsight.com/hangfire-task-scheduler-for-net/

https://www.infoworld.com/article/3050769/how-to-work-with-hangfire-in-c.html

https://www.youtube.com/watch?v=sQyY0xvJ4-o&ab_channel=DotNetCoreCentral