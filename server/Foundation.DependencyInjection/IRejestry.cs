namespace Foundation.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IRejestry
    {
        void ConfigureServices(IServiceCollection services);
    }
}
