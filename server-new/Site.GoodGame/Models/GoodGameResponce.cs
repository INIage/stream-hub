namespace Site.GoodGame.Models;

using System.Text.Json.Nodes;

internal class GoodGameResponce<T>
{
    public T? data;
    public string type = default!;
}

internal class GoodGameResponce : GoodGameResponce<JsonObject> { }
