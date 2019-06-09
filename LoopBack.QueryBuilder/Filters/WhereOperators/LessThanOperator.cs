using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class LessThanOperator : WhereOperatorBase<object>
    {
        private readonly bool orEqual;

        public override WhereOperatorKind Operator => this.orEqual ? WhereOperatorKind.Lte : WhereOperatorKind.Lt;

        public LessThanOperator(string property, object value, bool orEqual = false)
        {
            this.Property = property;
            this.Value = value;
            this.orEqual = orEqual;
        }
    }
}
