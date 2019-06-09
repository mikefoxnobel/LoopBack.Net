using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable IdentifierTypo

namespace LoopBack.QueryBuilder.Enumerations
{
    public enum WhereOperatorKind
    {
        Equal,
        And,
        Or,
        Gt,
        Gte,
        Lt,
        Lte,
        Between,
        Inq,
        Nin,
        Near,
        Neq,
        Like,
        Nlike,
        Regexp,
    }
}
