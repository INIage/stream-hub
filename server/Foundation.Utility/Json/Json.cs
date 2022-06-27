namespace Foundation.Utility.Json
{
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Text.Unicode;

    public static class Json
    {
        private static JsonSerializerOptions options = new ()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            IncludeFields = true,
            IgnoreReadOnlyProperties = false,
            IgnoreReadOnlyFields = false,
            IgnoreNullValues = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            AllowTrailingCommas = true,
            ReferenceHandler = null,
            WriteIndented = false,
        };
        
        public static T Deserialize<T>(string str)
        {
            return JsonSerializer.Deserialize<T>(str, options);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return JsonSerializer.Deserialize<T>(bytes, options);
        }

        public static byte[] Serialize<T>(T obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes(obj, options);
        }
    }
}
