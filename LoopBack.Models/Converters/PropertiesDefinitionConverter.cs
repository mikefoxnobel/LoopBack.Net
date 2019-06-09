using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoopBack.Models.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            JObject obj = JObject.Load(reader);
            PropertiesDefinition result = new PropertiesDefinition();

            foreach (JProperty prop in obj.Properties())
            {
                string key = prop.Name;

                PropertyDefinition value;
                if (prop.Value.Type == JTokenType.String)
                {
                    value = new PropertyDefinition(prop.Value.ToObject<LoopBackType>());
                }
                else
                {
                    value = prop.Value.ToObject<PropertyDefinition>();
                }
                    
                result.Add(key, value);
            }
            return result;
        }
    }
}
