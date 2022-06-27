namespace Utility.Extentions;

using Microsoft.Extensions.DependencyInjection;
using System;

public static class ReflectionExtentions
{
    public static bool HasInterface<T>(this Type type)
    {
        return type.GetInterface(typeof(T).Name) is not null;
    }

    public static T CreateInstance<T>(this Type type)
    {
        return (T)Activator.CreateInstance(type);
    }

    public static T CreateInstance<T>(this Type type, IServiceProvider provider)
    {
        return (T)ActivatorUtilities.CreateInstance(provider, type);
    }
}
