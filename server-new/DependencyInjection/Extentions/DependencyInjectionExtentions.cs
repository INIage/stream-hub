namespace DependencyInjection.Extentions;

using Microsoft.Extensions.DependencyInjection;

using Reflection;
using Utility.Extentions;

public static class DependencyInjectionExtentions
{
    public static void AddDependencyInjection(this IServiceCollection service)
    {
        Reflect.GetRejestryes().Iter(rejestry => rejestry.ConfigureServices(service));
    }
}
