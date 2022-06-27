namespace Project.StreamHub
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main()
        {
            Host.Run();
        }

        private static IHost Host =>
            new HostBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                bool reloadOnChange = context.Configuration.GetValue("hostBuilder:reloadConfigOnChange", defaultValue: true);
                config.AddJsonFile("appsettings.json", true, reloadOnChange);
            })
            .ConfigureLogging((context, logging) =>
            {
                logging
                    .AddConfiguration(context.Configuration.GetSection("Logging"))
                    .AddConsole()
                    .AddDebug()
                    .AddEventSourceLogger()
                    .Configure(options =>
                    {
                        options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId | ActivityTrackingOptions.TraceId | ActivityTrackingOptions.ParentId;
                    });
            })
            .ConfigureWebHost(builder =>
            {
                builder
                    .UseKestrel()
                    .UseStartup<Startup>();
            })
            .Build();
    }
}
