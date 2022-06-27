namespace StreamHub
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using DependencyInjection;
    using WebSocket;

    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection();
            services.AddRouting();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWebSockets();
            app.UseWebSocketServer();
        }
    }
}
