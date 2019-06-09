using System;
using LoopBack.QueryBuilder.Extensions;
using LoopBack.QueryBuilder.Filters.WhereOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoopBack.QueryBuilder.Tests
{
    [TestClass]
    public class WhereOperatorTest
    {
        [TestMethod]
        public void EqualOperator_Int()
        {
            EqualOperator equalOperator = new EqualOperator("TestProperty", 1);
            string result = equalOperator.Serialize();
            Assert.AreEqual(result, "{\"TestProperty\":1}");
        }

        [TestMethod]
        public void EqualOperator_String()
        {
            EqualOperator equalOperator = new EqualOperator("TestProperty", "TestString");
            string result = equalOperator.Serialize();
            Assert.AreEqual(result, "{\"TestProperty\":\"TestString\"}");
        }

        [TestMethod]
        public void AndOperator_EqualEqual()
        {
            EqualOperator equalOperator1 = new EqualOperator("TestProperty1", "TestString1");
            EqualOperator equalOperator2 = new EqualOperator("TestProperty2", "TestString2");
            AndOperator andOperator = new AndOperator(equalOperator1, equalOperator2);
            string result = andOperator.Serialize();
            Assert.AreEqual(result, "{\"and\":[{\"TestProperty1\":\"TestString1\"},{\"TestProperty2\":\"TestString2\"}]}");
        }

        [TestMethod]
        public void OrOperator_EqualEqual()
        {
            EqualOperator equalOperator1 = new EqualOperator("TestProperty1", "TestString1");
            EqualOperator equalOperator2 = new EqualOperator("TestProperty2", "TestString2");
            OrOperator orOperator = new OrOperator(equalOperator1, equalOperator2);
            string result = orOperator.Serialize();
            Assert.AreEqual(result, "{\"or\":[{\"TestProperty1\":\"TestString1\"},{\"TestProperty2\":\"TestString2\"}]}");
        }

        [TestMethod]
        public void AndOperator_AndOr()
        {
            EqualOperator equalOperator1 = new EqualOperator("TestProperty1", "TestString1");
            EqualOperator equalOperator2 = new EqualOperator("TestProperty2", "TestString2");
            AndOperator andOperator = new AndOperator(equalOperator1, equalOperator2);
            EqualOperator equalOperator3 = new EqualOperator("TestProperty3", "TestString3");
            OrOperator orOperator = andOperator.Or(equalOperator3);
            string result = orOperator.Serialize();
            Assert.AreEqual(result, "{\"or\":[{\"and\":[{\"TestProperty1\":\"TestString1\"},{\"TestProperty2\":\"TestString2\"}]},{\"TestProperty3\":\"TestString3\"}]}");
        }

        [TestMethod]
        public void AndOperator_AndAnd()
        {
            EqualOperator equalOperator1 = new EqualOperator("TestProperty1", "TestString1");
            EqualOperator equalOperator2 = new EqualOperator("TestProperty2", "TestString2");
            AndOperator andOperator = new AndOperator(equalOperator1, equalOperator2);
            EqualOperator equalOperator3 = new EqualOperator("TestProperty3", "TestString3");
            andOperator = andOperator.And(equalOperator3);
            string result = andOperator.Serialize();
            Assert.AreEqual(result, "{\"and\":[{\"TestProperty1\":\"TestString1\"},{\"TestProperty2\":\"TestString2\"},{\"TestProperty3\":\"TestString3\"}]}");
        }
    }
}
