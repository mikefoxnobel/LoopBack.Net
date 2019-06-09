using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopBack.QueryBuilder.Filters
{
    public class IncludeRelation : IBaseFilter
    {
        public string Relation { get; set; }
        public Filter Scope { get; set; }

        public IncludeRelation(string relation, Filter scope = null)
        {
            this.Relation = relation;
            this.Scope = scope;
        }
    }
}
