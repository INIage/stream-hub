namespace Utility.Extentions;

using Utility.Option;

public static class EnumerableOptionExtentions
{
    public static void IterOption<T>(this IEnumerable<Option<T>> options, Action<T> action)
    {
        options.Iter(option => option.Iter(action));
    }

    public static Task IterOption<T>(this IEnumerable<Option<T>> options, Func<T, Task> action)
    {
        return options.Map(option => option.Iter(action)).WhenAll();
    }
}
