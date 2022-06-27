namespace DependencyInjection.Reflection;


using System.Collections.Generic;
using Utility;
using Utility.Extentions;

internal static class Reflect
{
    public static IEnumerable<IRejestry> GetRejestryes()
    {
        return Application.GetAssemblies()
            .Collect(assembly => assembly.GetTypes())
            .Filter(type => type.HasInterface<IRejestry>())
            .Map(type => type.CreateInstance<IRejestry>());
    }
}
