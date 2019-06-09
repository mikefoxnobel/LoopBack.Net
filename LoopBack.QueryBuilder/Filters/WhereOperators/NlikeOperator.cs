using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;

// ReSharper disable IdentifierTypo

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public sealed class NlikeOperator : WhereOperatorBase<string>
    {
        public override WhereOperatorKind Operator => WhereOperatorKind.Nlike;

        public NlikeOperator(string property, string regex)
        {
            this.Property = property;
            this.Value = regex;
        }
    }
}
