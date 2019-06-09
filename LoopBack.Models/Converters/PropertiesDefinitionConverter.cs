using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LoopBack.Models.Converters
{
    public class PropertiesDefinitionConverter : JsonConverter<PropertiesDefinition>
    {
        public override void WriteJson(JsonWriter writer, PropertiesDefinition value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (string key in value.Keys)
            {
                writer.WritePropertyName(key);
                writer.WriteValue(value[key]);
            }
            writer.WriteEndObject();
        }

        public override PropertiesDefinition ReadJson(JsonReader reader, Type objectType, PropertiesDefinition existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
