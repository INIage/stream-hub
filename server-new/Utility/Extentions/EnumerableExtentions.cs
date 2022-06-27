namespace Utility.Extentions;

using System;
using System.Collections.Generic;

public static class EnumerableExtentions
{
    public static void Iter<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            action(enumerator.Current);
        }
    }

    public static void Iter<T>(this IEnumerable<T> enumerable, Action<T, int> action)
    {
        using var enumerator = enumerable.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            action(enumerator.Current, i);
        }
    }

    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, R> callback)
    {
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return callback(enumerator.Current);
        }
    }

    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, Task<R>> callback)
    {
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return callback(enumerator.Current).Result;
        }
    }

    public static IEnumerable<R> Map<T, R>(this IEnumerable<T> enumerable, Func<T, int, R> callback)
    {
        using var enumerator = enumerable.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            yield return callback(enumerator.Current, i);
        }
    }

    public static IEnumerable<R> Collect<T, R>(this IEnumerable<T> enumerable, Func<T, IEnumerable<R>> callback)
    {
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var enumerable2 = callback(enumerator.Current);

            using var enumerator2 = enumerable2.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                yield return enumerator2.Current;
            }
        }
    }

    public static IEnumerable<R> Collect<T, R>(this IEnumerable<T> enumerable, Func<T, int, IEnumerable<R>> callback)
    {
        using var enumerator = enumerable.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            var enumerable2 = callback(enumerator.Current, i);

            using var enumerator2 = enumerable2.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                yield return enumerator2.Current;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, bool> action)
    {
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (action(enumerator.Current))
            {
                yield return enumerator.Current;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, int, bool> action)
    {
        using var enumerator = enumerable.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); i++)
        {
            if (action(enumerator.Current, i))
            {
                yield return enumerator.Current;
            }
        }
    }

    public static R Reduce<T, R>(this IEnumerable<T> enumerable, Func<R, T, R> callback, R initial)
    {
        enumerable.Iter(current => { initial = callback(initial, current); });
        return initial;
    }

    public static R Reduce<T, R>(this IEnumerable<T> enumerable, Func<R, T, int, R> callback, R initial)
    {
        enumerable.Iter((current, i) => { initial = callback(initial, current, i); });
        return initial;
    }

    public static Task WhenAll(this IEnumerable<Task> enumerable)
    {
        return Task.WhenAll(enumerable);
    }

    public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> enumerable)
    {
        return await Task.WhenAll(enumerable);
    }

    public static void WaitAll(this IEnumerable<Task> enumerable)
    {
        Task.WaitAll(enumerable.ToArray());
    }

    public static Task<T> WaitAny<T>(this IEnumerable<Task<T>> enumerable)
    {
        var array = enumerable.ToArray();
        var index = Task.WaitAny(array);
        return array[index];
    }
}
