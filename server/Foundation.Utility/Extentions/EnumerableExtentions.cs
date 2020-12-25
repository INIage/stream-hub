namespace Foundation.Utility.Extentions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class EnumerableExtentions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); i++)
            {
                action(enumerator.Current, i);
            }
        }

        public static IEnumerable<R> ForEach<T, R>(this IEnumerable<T> enumerable, Func<T, R> callback)
        {
            using var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return callback(enumerator.Current);
            }
        }

        public static IEnumerable<R> ForEach<T, R>(this IEnumerable<T> enumerable, Func<T, int, R> callback)
        {
            using var enumerator = enumerable.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); i++)
            {
                yield return callback(enumerator.Current, i);
            }
        }

        public static T Find<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            return enumerable
                .Filter(condition)
                .First();
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            using var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (condition(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Func<T, int, bool> condition)
        {
            using var enumerator = enumerable.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); i++)
            {
                if (condition(enumerator.Current, i))
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static R Reduce<T, R>(this IEnumerable<T> enumerable, Func<R, T, R> callback, R initial)
        {
            var previous = initial;

            enumerable.ForEach(current => { previous = callback(previous, current); });

            return previous;
        }

        public static R Reduce<T, R>(this IEnumerable<T> enumerable, Func<R, T, int, R> callback, R initial)
        {
            var previous = initial;

            enumerable.ForEach((current, i) => { previous = callback(previous, current, i); });

            return previous;
        }

        public static IEnumerable<R> Cast<R>(this IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is R current)
                {
                    yield return current;
                }
            }
        }

        public static int Count<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Reduce((previous, _) => previous + 1, 0);
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> enumerable, int count)
        {
            return enumerable.Filter((current, i) => i >= count);
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumerable, int count)
        {
            return enumerable.Filter((current, i) => i < count);
        }

        public static T First<T>(this IEnumerable<T> enumerable)
        {
            /*
            T CreateInstance()
            {
                var type = typeof(T);
                T instance = default;

                if (type.IsInstanceOfType(typeof(object)))
                {
                    type.GetConstructors()
                       .Filter(constructor => constructor.GetParameters().Length == 0)
                       .ForEach(constructor =>
                       {
                           instance = (T)constructor.Invoke(Array.Empty<object>());
                       });
                }

                return instance;
            }
            */
            using var enumerator = enumerable.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : default;
        }

        public static void First<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            if (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }

        public static R First<T, R>(this IEnumerable<T> enumerable, Func<T, R> callback)
        {
            using var enumerator = enumerable.GetEnumerator();
            if (enumerator.MoveNext())
            {
                return callback(enumerator.Current);
            }

            return default;
        }

        public static T[] ToArray<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Reduce(
                (array, current, i) =>
                {
                    array[i] = current;
                    return array;
                }, new T[enumerable.Count()]);
        }

        public static List<T> ToList<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Reduce(
                (list, current) =>
                {
                    list.Add(current);
                    return list;
                }, new List<T>());
        }
    }
}
