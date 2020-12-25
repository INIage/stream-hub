namespace Foundation.WebSockets
{
    using Microsoft.Extensions.DependencyInjection;

    using Foundation.DependencyInjection;

    using Server.Reflection;

    public class Rejestry: IRejestry
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Reflect>();
        }
    }
}
