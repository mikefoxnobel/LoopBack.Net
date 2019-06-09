using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class InOperator : WhereOperatorBase<IEnumerable<object>>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Inq;

        public InOperator(string property, params object[] values)
        {
            this.Property = property;
            this.Value = new List<object>(values);
        }
    }
}
