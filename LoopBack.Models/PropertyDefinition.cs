using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LoopBack.Models.Converters;
using LoopBack.Models.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoopBack.Models
{
    public class PropertyDefinition
    {
        [DefaultValue("")]
        public string Default { get; set; } = "";

        [DefaultValue(DefaultFunction.None)]
        public DefaultFunction DefaultFn { get; set; } = DefaultFunction.None;

        [DefaultValue("")]
        public string Description { get; set; } = "";

        [JsonIgnore]
        [Obsolete("Deprecated, use \"Description\" instead.")]
        public string Doc
        {
            get => this.Description;
            set => this.Description = value;
        }

        private int _id = 0;

        [DefaultValue("false")]
        [JsonConverter(typeof(StringJrawConverter))]
        public string Id
        {
            get
            {
                if (_id <= 0)
                {
                    return "false";
                }
                else if (_id == 1)
                {
                    return "true";
                }
                else
                {
                    return _id.ToString();
                }
            }
            set
            {
                if (value.Equals("false"))
                {
                    this._id = 0;
                }
                else if (value.Equals("true"))
                {
                    this._id = 1;
                }
                else
                {
                    try
                    {
                        this._id = Convert.ToInt32(value);
                    }
                    catch (FormatException)
                    {
                        throw;
                    }
                    catch (OverflowException)
                    {
                        throw;
                    }
                }
            }
        }

        [DefaultValue(false)]
        public bool Index { get; set; } = false;

        [DefaultValue(false)]
        public bool Required { get; set; } = false;

        public LoopBackType Type { get; set; }

        public PropertyDefinition(LoopBackType type)
        {
            this.Type = type;
        }
    }
}
