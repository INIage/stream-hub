namespace Chat.Models;

using System.Text.Json.Nodes;

internal sealed class Connect
{
    public IDictionary<string, JsonObject> connections;
}
