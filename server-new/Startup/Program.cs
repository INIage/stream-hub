namespace StreamHub.Startup;

using Utility.Extentions;
using Utility.Option;

public static class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.ConfigureBuilder();

        var app = builder.Build();
        app.ConfigureApplication();

        app.Run();
    }

    public static void Main0()
    {
        var list = new List<Option<int>> { Option.Some(1), Option.Some(5), Option.None<int>() };

        var list2 = list
            .Map(option => option.Map(number => number + 2))
            .Filter(option => option.IsSome())
            ;
    }
}
