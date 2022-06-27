namespace StreamHub
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
                var reloadOnChange = context.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                config.AddJsonFile("appsettings.json", true, reloadOnChange);
            })
            .ConfigureLogging((context, logging) =>
            {
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
                logging.Configure(options =>
                {
                    options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId | ActivityTrackingOptions.TraceId | ActivityTrackingOptions.ParentId;
                });
            })
            .ConfigureWebHost(builder =>
            {
                builder.UseKestrel();
                builder.UseStartup<Startup>();
            })
            .Build();
    }
}
