using System;

namespace LoopBack.Models
{
    public class ModelDefinition
    {
        public string Name { get; set; }
        public string[] Description { get; set; }
        public string Base { get; set; }
        public bool IdInjection { get; set; }
        public bool Strict { get; set; }
        public bool ForceId { get; set; }
        public object Options { get; set; }
        public PropertiesDefinition Properties { get; set; }
        public object[] Hidden { get; set; }
        public object[] Validations { get; set; }
        public object Relations { get; set; }
        public object[] Acls { get; set; }
        public object Scopes { get; set; }
        public object Indexes { get; set; }
        public object[] Methods { get; set; }
        public object Http { get; set; }
    }
}
