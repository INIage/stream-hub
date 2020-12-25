namespace Foundation.Connect
{
    using Microsoft.Extensions.DependencyInjection;

    using Foundation.DependencyInjection;

    using Managers;
    using Reflection;

    public class Rejestry: IRejestry
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Reflect>();
            services.AddSingleton<IMessageManager, MessageManager>();
        }
    }
}
