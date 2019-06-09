using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class LikeOperator : WhereOperatorBase<string>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Like;

        public LikeOperator(string property, string regex)
        {
            this.Property = property;
            this.Value = regex;
        }
    }
}
