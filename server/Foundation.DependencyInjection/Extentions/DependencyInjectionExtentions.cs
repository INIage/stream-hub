namespace Foundation.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    using Foundation.Utility.Extentions;

    using Reflection;

    public static class DependencyInjectionExtentions
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            Reflect.GetRejestryes()
                .Filter(rejestry => rejestry is not null)
                .ForEach(rejestry => rejestry.ConfigureServices(service));
        }
    }
}
