using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Filters;
using LoopBack.QueryBuilder.Filters.WhereOperators;
using LoopBack.QueryBuilder.JsonConverters;
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
            converters.Add(new WhereOperatorConverter());
            converters.Add(new StringEnumConverter());
            serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                NullValueHandling = NullValueHandling.Ignore,
                Converters = converters,
            };
        }

        public static string Serialize(this Filter filter)
        {
            string result = JsonConvert.SerializeObject(filter, Formatting.None, serializerSettings);
            return result;
        }

        public static string Serialize(this WhereOperatorBase whereOperator)
        {
            string result = JsonConvert.SerializeObject(whereOperator, Formatting.None, serializerSettings);
            return result;
        }

        public static string Serialize(this object source)
        {
            string result = JsonConvert.SerializeObject(source, Formatting.None, serializerSettings);
            return result;
        }
    }
}