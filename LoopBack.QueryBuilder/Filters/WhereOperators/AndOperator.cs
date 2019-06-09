using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class AndOperator : WhereOperatorBase<List<WhereOperatorBase>>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.And;

        public AndOperator(WhereOperatorBase whereOperator1, WhereOperatorBase whereOperator2, params WhereOperatorBase[] whereOperators)
        {
            this.Value = new List<WhereOperatorBase>
            {
                whereOperator1,
                whereOperator2
            };
            this.Value.AddRange(whereOperators);
        }

        public override AndOperator And(WhereOperatorBase whereOperator, params WhereOperatorBase[] whereOperators)
        {
            this.Value.Add(whereOperator);
            this.Value.AddRange(whereOperators);
            return this;
        }
    }
}
