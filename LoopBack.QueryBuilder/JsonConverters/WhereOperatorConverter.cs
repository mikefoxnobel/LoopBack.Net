using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Extensions;
using LoopBack.QueryBuilder.Enumerations;
using LoopBack.QueryBuilder.Filters.WhereOperators;
using Newtonsoft.Json;

namespace LoopBack.QueryBuilder.JsonConverters
{
    public class WhereOperatorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                if (value is WhereOperatorBase whereOperator)
                {
                    if (string.IsNullOrWhiteSpace(whereOperator.Property))
                    {
                        this.WriteWhereOperator(writer, whereOperator);
                    }
                    else
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName(whereOperator.Property);
                        this.WriteWhereOperator(writer, whereOperator);
                        writer.WriteEndObject();
                    }
                }
                else
                {
                    throw new NullReferenceException("Value must be a instance of WhereOperatorBase.");
                }
            }
            catch
            {
                throw;
            }
        }

        private void WriteWhereOperator(JsonWriter writer, WhereOperatorBase whereOperator)
        {
            if (whereOperator.Operator == WhereOperatorKind.Equal)
            {
                writer.WriteValue(whereOperator.Value);
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName(whereOperator.Operator.ToString().ToLower());
                string valueJson = whereOperator.Value.Serialize();
                writer.WriteRawValue(valueJson);
                writer.WriteEndObject();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(WhereOperatorBase));
        }
    }
}
