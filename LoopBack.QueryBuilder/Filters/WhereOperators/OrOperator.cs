using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class OrOperator : WhereOperatorBase<List<WhereOperatorBase>>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Or;

        public OrOperator(WhereOperatorBase whereOperator1, WhereOperatorBase whereOperator2, params WhereOperatorBase[] whereOperators)
        {
            this.Value = new List<WhereOperatorBase>
            {
                whereOperator1,
                whereOperator2
            };
            this.Value.AddRange(whereOperators);
        }

        public override OrOperator Or(WhereOperatorBase whereOperator, params WhereOperatorBase[] whereOperators)
        {
            this.Value.Add(whereOperator);
            this.Value.AddRange(whereOperators);
            return this;
        }
    }
}
