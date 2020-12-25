namespace Feature.GoodGame
{
    using Microsoft.Extensions.DependencyInjection;

    using Foundation.DependencyInjection;

    using Managers;
    using Mapper;
    using Services;

    internal class Rejestry: IRejestry
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<GoodGame>();
            services.AddTransient<IMessageManager, MessageManager>();
            services.AddTransient<IGoodGameMapper, GoodGameMapper>();
            services.AddTransient<IGoodGameService, GoodGameService>();
        }
    }
}
