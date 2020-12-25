namespace Foundation.Utility.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class AsyncEnumerableExtentions
    {
        public static async Task ForEach<T>(this IAsyncEnumerable<T> enumerable, Action<T> action)
        {
            var enumerator = enumerable.GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                action(enumerator.Current);
            }
        }

        public static async Task ForEach<T>(this IAsyncEnumerable<T> enumerable, Action<T, int> action)
        {
            var enumerator = enumerable.GetAsyncEnumerator();
            for (int i = 0; await enumerator.MoveNextAsync(); i++)
            {
                action(enumerator.Current, i);
            }
        }

        public static async Task<R> Reduce<T, R>(this IAsyncEnumerable<T> enumerable, Func<R, T, R> callback, R initial)
        {
            var previous = initial;

            await enumerable.ForEach(current => { previous = callback(previous, current); });

            return previous;
        }

        public static async Task<R> Reduce<T, R>(this IAsyncEnumerable<T> enumerable, Func<R, T, int, R> callback, R initial)
        {
            var previous = initial;

            await enumerable.ForEach((current, i) => { previous = callback(previous, current, i); });

            return previous;
        }

        public static async Task<int> Count<T>(this IAsyncEnumerable<T> enumerable)
        {
            return await enumerable.Reduce((previous, _) => previous + 1, 0);
        }

        public static async Task<T[]> ToArray<T>(this IAsyncEnumerable<T> enumerable)
        {
            return await enumerable.Reduce(
                (array, current, i) =>
                {
                    array[i] = current;
                    return array;
                }, new T[await enumerable.Count()]);
        }
    }
}
