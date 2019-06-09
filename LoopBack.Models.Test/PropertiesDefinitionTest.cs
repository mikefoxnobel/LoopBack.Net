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

            string result = properties.Serialize();

        }

        [TestMethod]
        public void SerializeProperties_Two()
        {
            PropertiesDefinition properties = new PropertiesDefinition();
            properties.Add("property1", new PropertyDefinition(LoopBackType.Number));
            properties.Add("property2", new PropertyDefinition(LoopBackType.String));

            string result = properties.Serialize();
        }
    }
}
