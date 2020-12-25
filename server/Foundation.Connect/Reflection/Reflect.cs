namespace Foundation.Connect.Reflection
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

        public Dictionary<string, IConnecter> GetClients()
        {
            return GetApplicationAssemblies()
                .Reduce((dictionary, assembly) =>
                {
                    assembly.GetTypes()
                        .Filter(type => type.HasInterface<IConnecter>())
                        .First(type => 
                        {
                            var attribute = type.GetCustomAttribute<SiteNameAttribute>();
                            if (attribute is not null)
                            {
                                dictionary.Add(
                                    attribute.Name.ToLower(),
                                    type.CreateInstance<IConnecter>(provider));
                            }
                        });

                    return dictionary;
                }, new Dictionary<string, IConnecter>());
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
