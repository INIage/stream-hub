namespace Utility.Option;

public interface Option<out T> { }

public sealed class Some<T> : Option<T>
{
    public T Value { get; init; }

    public Some(T value)
    {
        Value = value;
    }
}

public sealed class None<T> : Option<T> { }

public interface Option
{
    public static Action Skip = () => { };
    public static Option<T> Some<T>(T value) => new Some<T>(value);
    public static Option<T> None<T>() => new None<T>();
}
