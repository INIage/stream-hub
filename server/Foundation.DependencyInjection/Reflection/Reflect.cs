namespace Foundation.DependencyInjection.Reflection
{
    using System.Collections.Generic;
    using System.Reflection;

    using Microsoft.AspNetCore.Mvc.ApplicationParts;

    using Foundation.Utility.Extentions;

    internal static class Reflect
    {
        public static IEnumerable<IRejestry> GetRejestryes()
        {
            foreach (var assembly in GetApplicationAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.HasInterface<IRejestry>())
                    {
                        yield return type.CreateInstance<IRejestry>();
                    }
                }
            }
        }

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            return Assembly
                .GetEntryAssembly()
                .GetCustomAttributes<ApplicationPartAttribute>()
                .ForEach(attribute => Assembly.Load(attribute.AssemblyName));
        }
    }
}
