namespace Project.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Text.Unicode;
    using Foundation.Utility.Extentions;

    class Program
    {
        static void Main(string[] args)
        {
            var welcome = new Response {
                data = new Message
                {
                    user_name = "Nage",
                    text = "Привет чат!",
                }, 
                type = "message" };

            var option = new JsonSerializerOptions
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

            var json = JsonSerializer.Serialize(welcome, option);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }

    public record Response
    {
        public dynamic data;
        public string type;
    }
    public record Message
    {
        public string user_name;
        public string text;
    }
}
