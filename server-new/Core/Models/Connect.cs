namespace Core.Models;

using System.Text.Json.Nodes;

public sealed class Connect : Data
{
    public IDictionary<string, JsonObject> connections;
}
