using System;
using System.Security.Cryptography;
using LoopBack.Models;
using LoopBack.Models.Enumerations;
using LoopBack.QueryBuilder.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoopBack.Models.Test
{
    [TestClass]
    public class PropertiesDefinitionTest
    {
        [TestMethod]
        public void SerializeProperties_One()
        {
            PropertiesDefinition properties = new PropertiesDefinition();
            properties.Add("property1", new PropertyDefinition(LoopBackType.Number));

            string json = properties.Serialize();

        }

        [TestMethod]
        public void SerializeProperties_Two()
        {
            PropertiesDefinition properties = new PropertiesDefinition();
            properties.Add("property1", new PropertyDefinition(LoopBackType.Number));
            properties.Add("property2", new PropertyDefinition(LoopBackType.String));

            string json = properties.Serialize();
        }

        [TestMethod]
        public void DeserializeProperties_One_TypeOnly()
        {
            string json = "{\"property1\":\"string\"}";
            PropertiesDefinition properties = json.Deserialize<PropertiesDefinition>();
        }

        [TestMethod]
        public void DeserializeProperties_One_Complete()
        {
            string json = "{\"property1\":{\"type\":\"string\", \"id\":true, \"description\":\"This is Property 1\"}}";
            PropertiesDefinition properties = json.Deserialize<PropertiesDefinition>();
        }
    }
}
