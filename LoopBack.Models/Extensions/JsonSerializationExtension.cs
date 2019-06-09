using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.Models;
using LoopBack.Models.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LoopBack.QueryBuilder.Extensions
{
    public static class JsonSerializationExtension
    {
        private static readonly JsonSerializerSettings serializerSettings;
        private static readonly List<JsonConverter> converters = new List<JsonConverter>();

        static JsonSerializationExtension()
        {
            converters.Add(new StringEnumConverter());
            converters.Add(new PropertiesDefinitionConverter());
            serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                Converters = converters,
            };
        }

        public static string Serialize(this ModelDefinition filter)
        {
            string result = JsonConvert.SerializeObject(filter, Formatting.None, serializerSettings);
            return result;
        }

        public static string Serialize(this PropertiesDefinition whereOperator)
        {
            string result = JsonConvert.SerializeObject(whereOperator, Formatting.None, serializerSettings);
            return result;
        }

        public static string Serialize(this object source)
        {
            string result = JsonConvert.SerializeObject(source, Formatting.None, serializerSettings);
            return result;
        }

        public static T Deserialize<T>(this string json)
        {
            T result = JsonConvert.DeserializeObject<T>(json, serializerSettings);
            return result;
        }
    }
}