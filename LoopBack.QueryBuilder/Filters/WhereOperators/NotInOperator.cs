using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class NotInOperator : WhereOperatorBase<IEnumerable<object>>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Nin;

        public NotInOperator(string property, params object[] values)
        {
            this.Property = property;
            this.Value = new List<object>(values);
        }
    }
}
