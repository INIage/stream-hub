namespace Foundation.Utility.Extentions
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    public static class AssemblyExtentions
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
}
