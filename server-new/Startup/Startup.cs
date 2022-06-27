namespace StreamHub.Startup;

using DependencyInjection.Extentions;

public static class Startup
{
    public static void ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureServices();
        builder.Logging.ConfigureLogging();
    }

    public static void ConfigureServices(this IServiceCollection builder)
    {
        builder.AddControllers();        
        builder.AddDependencyInjection();
    }

    public static void ConfigureLogging(this ILoggingBuilder builder)
    {
        builder.AddConsole();
    }

    public static void ConfigureApplication(this WebApplication app)
    {
        //app.UseAuthorization();
        //app.UseRouting();
        app.MapControllers();

        app.UseWebSockets();
    }
}
