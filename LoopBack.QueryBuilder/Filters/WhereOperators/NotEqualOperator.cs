using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class NotEqualOperator : WhereOperatorBase<object>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Neq;

        public NotEqualOperator(string property, object value)
        {
            this.Property = property;
            this.Value = value;
        }
    }
}
