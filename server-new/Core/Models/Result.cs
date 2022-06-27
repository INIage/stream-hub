namespace Core.Models;

using System.Text.Json.Nodes;
using Utility.Serialization;

public sealed class Reply
{
    public JsonNode data = default!;
    public string type = default!;

    public static Reply New<T>(T data, string type = null!) where T : Data
    {
        return new Reply
        {
            data = Json.SerializeToNode(data),
            type = type ?? typeof(T).Name,
        };
    }
}
