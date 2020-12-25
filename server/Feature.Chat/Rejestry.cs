namespace Feature.Chat
{
    using Microsoft.Extensions.DependencyInjection;

    using Foundation.DependencyInjection;

    using Managers;
    using Services;

    internal class Rejestry: IRejestry
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageManager, MessageManager>();
            services.AddTransient<IChatService, ChatService>();
        }
    }
}
