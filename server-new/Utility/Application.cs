namespace Utility;

using System.Reflection;

public static class Application
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        return AppDomain.CurrentDomain.GetAssemblies().AsEnumerable();
    }
}
