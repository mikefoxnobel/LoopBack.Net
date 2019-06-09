using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace LoopBack.QueryBuilder.Enumerations
{
    public enum OrderKind
    {
        // ReSharper disable InconsistentNaming
        [Description("Ascending")]
        ASC,
        [Description("Decending")]
        DESC,
        // ReSharper restore InconsistentNaming
    }
}
