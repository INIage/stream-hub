namespace Utility.Serialization;

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;

public static class Json
{
    private static readonly JsonSerializerOptions options = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        IncludeFields = true,
        IgnoreReadOnlyProperties = false,
        IgnoreReadOnlyFields = false,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        AllowTrailingCommas = true,
        ReferenceHandler = null,
        WriteIndented = false,
    };

    public static T Deserialize<T>(ReadOnlySpan<char> str)
    {
        var result = JsonSerializer.Deserialize<T>(str, options);
        if (result is null) throw new NullReferenceException("result of deseserializetion is null");

        return result;
    }

    public static T Deserialize<T>(byte[] bytes)
    {
        var result = JsonSerializer.Deserialize<T>(bytes, options);
        if (result is null) throw new NullReferenceException("result of deseserializetion is null");

        return result;
    }

    public static T Deserialize<T>(JsonNode? json)
    {
        var result = JsonSerializer.Deserialize<T>(json, options);
        if (result is null) throw new NullReferenceException("result of deseserializetion is null");

        return result;
    }

    public static byte[] SerializeToUtf8Bytes<T>(T obj)
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj, options);
    }

    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, options);
    }

    public static JsonNode SerializeToNode<T>(T obj)
    {
        var result = JsonSerializer.SerializeToNode(obj, options);
        if (result is null) throw new NullReferenceException("result of seserializetion is null");

        return result;
    }
}
