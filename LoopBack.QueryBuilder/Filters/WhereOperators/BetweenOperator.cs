using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class BetweenOperator : WhereOperatorBase<object[]>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Between;
        public override object[] Value { get; protected set; }

        public BetweenOperator(string property, object value1, object value2)
        {
            this.Property = property;
            this.Value = new object[2] { value1, value2 };
        }
    }
}
