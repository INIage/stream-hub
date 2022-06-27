namespace Site.GoodGame.Models;
internal class GoodGameRequest<T> where T : Data
{
    public T? data;
    public string type = default!;
}

internal class GoodGameRequest : GoodGameRequest<Data> { }
