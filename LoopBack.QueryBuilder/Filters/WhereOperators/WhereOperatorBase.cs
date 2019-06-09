using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopBack.QueryBuilder.Enumerations;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LoopBack.QueryBuilder.Filters.WhereOperators
{
    public abstract class WhereOperatorBase<T> : WhereOperatorBase
    {
        public new virtual T Value
        {
            get => (T)base.Value;
            protected set => base.Value = value;
        }
    }

    public abstract class WhereOperatorBase
    {
        public virtual string Property { get; internal set; } = String.Empty;

        public abstract WhereOperatorKind Operator { get; }

        public virtual object Value { get; protected set; }

        public virtual AndOperator And(WhereOperatorBase whereOperator, params WhereOperatorBase[] whereOperators)
        {
            AndOperator result = new AndOperator(this, whereOperator, whereOperators);
            return result;
        }

        public virtual OrOperator Or(WhereOperatorBase whereOperator, params WhereOperatorBase[] whereOperators)
        {
            OrOperator result = new OrOperator(this, whereOperator, whereOperators);
            return result;
        }
    }
}
