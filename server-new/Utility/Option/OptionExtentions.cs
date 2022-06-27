namespace Utility.Option;

public static class OptionExtentions
{
    public static Option<R> Bind<T, R>(this Option<T> option, Func<T, Option<R>> binder)
    {
        if (option is Some<T> some)
        {
            return binder(some.Value);
        }
        else if (option is None<T>)
        {
            return Option.None<R>();
        }
        else if (option is None<R> none )
        {
            return none;
        }

        throw new ArgumentOutOfRangeException();        
    }

    public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate) 
    {
        if (option is Some<T> some)
        {
            return predicate(some.Value) ? some : Option.None<T>();
        }
        else if (option is None<T> none)
        {
            return none;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static S Fold<T, S>(this Option<T> option, Func<S, T, S> folder, S state)
    {
        if (option is Some<T> some)
        {
            return folder(state, some.Value);
        }
        else if (option is None<T>)
        {
            return state;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static Option<T> Flatten<T>(this Option<Option<T>> option)
    {
        if (option is Some<Option<T>> some)
        {
            return some.Value;
        }
        else if (option is None<Option<T>>)
        {
            return Option.None<T>();
        }

        throw new ArgumentOutOfRangeException();
    }

    public static T Get<T>(this Option<T> option)
    {
        if (option is Some<T> some)
        {
            return some.Value;
        }

        throw new ArgumentException("Option shold contains a value");
    }

    public static bool IsNone<T>(this Option<T> option)
    {
        if (option is Some<T>)
        {
            return false;
        }
        else if (option is None<T>)
        {
            return true;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static bool IsSome<T>(this Option<T> option)
    {
        if (option is Some<T>)
        {
            return true;
        }
        else if (option is None<T>)
        {
            return false;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static void Iter<T>(this Option<T> option, Action<T> action)
    {
        if (option is Some<T> some)
        {
            action(some.Value);
            return;
        }
        else if (option is None<T>)
        {
            return;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static async Task Iter<T>(this Option<T> option, Func<T, Task> action)
    {
        if (option is Some<T> some)
        {
            await action(some.Value);
            return;
        }
        else if (option is None<T> none)
        {
            return;
        }

        throw new ArgumentOutOfRangeException();
    }
    
    public static Option<R> Map<T, R>(this Option<T> option, Func<T, R> mapping)
    {
        if (option is Some<T> some)
        {
            return Option.Some(mapping(some.Value));
        }
        else if (option is None<T>)
        {
            return Option.None<R>();
        }
        else if (option is None<R> none)
        {
            return none;
        }

        throw new ArgumentOutOfRangeException();
    }
    
    public static void Match<T>(this Option<T> option, Action<T> onSome, Action onNone)
    {
        if (option is Some<T> some)
        {
            onSome(some.Value);
            return;
        }
        else if (option is None<T>)
        {
            onNone();
            return;
        }

        throw new ArgumentOutOfRangeException();
    }

    public static async Task Match<T>(this Option<T> option, Func<T, Task> onSome, Action onNone)
    {
        if (option is Some<T> some)
        {
            await onSome(some.Value);
            return;
        }
        else if (option is None<T>)
        {
            onNone();
            return;
        }

        throw new ArgumentOutOfRangeException();
    }
}
