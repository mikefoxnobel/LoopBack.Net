using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LoopBack.QueryBuilder.Enumerations;
using LoopBack.QueryBuilder.Filters.WhereOperators;
using LoopBack.QueryBuilder.JsonConverters;
using Newtonsoft.Json;

namespace LoopBack.QueryBuilder.Filters
{
    public class Filter : IBaseFilter
    {
        [JsonProperty("fields")]
        internal FieldsFilter FieldsFilter { get; set; }
        
        [JsonProperty("include")]
        internal IncludeFilter IncludeFilter { get; set; }

        [JsonProperty("limit")]
        internal uint? LimitFilter { get; set; } = null;

        [JsonProperty("order")]
        internal OrderFilter OrderFilter { get; set; }

        [JsonProperty("skip")]
        internal uint? SkipFilter { get; set; } = null;

        [JsonProperty("where")]
        [JsonConverter(typeof(WhereOperatorConverter))]
        internal WhereOperatorBase WhereFilter { get; set; }

        public Filter Fields(string field, bool isInclude)
        {
            if (this.FieldsFilter == null)
            {
                this.FieldsFilter = new FieldsFilter();
            }

            this.FieldsFilter.Add(field, isInclude);
            return this;
        }

        public Filter Fields(params string[] fields)
        {
            foreach (string field in fields)
            {
                this.Fields(field, true);
            }

            return this;
        }

        public Filter Include(params IncludeRelation[] includeRelations)
        {
            if (this.IncludeFilter == null)
            {
                this.IncludeFilter = new IncludeFilter();
            }

            this.IncludeFilter.AddRange(includeRelations);
            return this;
        }

        public Filter Include(params string[] relations)
        {
            foreach (string relation in relations)
            {
                this.Include(new IncludeRelation(relation));
            }

            return this;
        }

        public Filter Include(string relation, Filter scope)
        {
            return this.Include(new IncludeRelation(relation, scope));
        }

        public Filter Limit(uint count)
        {
            this.LimitFilter = count;
            return this;
        }

        public Filter Skip(uint count)
        {
            this.SkipFilter = count;
            return this;
        }

        public Filter Order(string field, OrderKind orderKind)
        {
            if (this.OrderFilter == null)
            {
                this.OrderFilter = new OrderFilter();
            }

            this.OrderFilter.Add($"{field} {orderKind}");
            return this;
        }

        public Filter Where(WhereOperatorBase whereOperator)
        {
            if (this.WhereFilter == null)
            {
                this.WhereFilter = whereOperator;
            }
            else
            {
                this.WhereFilter = this.WhereFilter.And(whereOperator);
            }
            return this;
        }
    }
}
