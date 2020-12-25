namespace Foundation.WebSockets.Server.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Microsoft.AspNetCore.Mvc.ApplicationParts;

    using Foundation.Utility.Extentions;

    internal class Reflect
    {
        private readonly IServiceProvider provider;

        public Reflect(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public Dictionary<string, Type> GetSockets()
        {
            return GetApplicationAssemblies()
                .Reduce((dictionary, assembly) =>
                {
                    assembly.GetTypes()
                        .Filter(type => type.HasInterface<ISocket>())
                        .ForEach(type =>
                        {
                            var attribute = type.GetCustomAttribute<SocketAttribute>();
                            if (attribute is not null)
                            {
                                dictionary.Add(
                                    attribute.Path,
                                    type);
                            }
                        });

                    return dictionary;
                }, new Dictionary<string, Type>());
        }

        private IEnumerable<Assembly> GetApplicationAssemblies()
        {
            return Assembly
                .GetEntryAssembly()
                .GetCustomAttributes<ApplicationPartAttribute>()
                .ForEach(attribute => Assembly.Load(attribute.AssemblyName));
        }
    }
}
