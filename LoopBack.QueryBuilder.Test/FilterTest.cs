using System;
using System.Security.AccessControl;
using LoopBack.QueryBuilder.Enumerations;
using LoopBack.QueryBuilder.Extensions;
using LoopBack.QueryBuilder.Filters;
using LoopBack.QueryBuilder.Filters.WhereOperators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoopBack.QueryBuilder.Tests
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void Filter_Where()
        {
            Filter filter = new Filter();
            filter.Where(new EqualOperator("PropertyName1", 1));
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"where\":{\"PropertyName1\":1}}");
        }

        [TestMethod]
        public void Filter_Include()
        {
            Filter filter = new Filter();
            filter.Include("Model1", "Model2", "Model3");
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"include\":[{\"relation\":\"Model1\"},{\"relation\":\"Model2\"},{\"relation\":\"Model3\"}]}");
        }

        [TestMethod]
        public void Filter_Limit()
        {
            Filter filter = new Filter();
            filter.Limit(100);
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"limit\":100}");
        }

        [TestMethod]
        public void Filter_Skip()
        {
            Filter filter = new Filter();
            filter.Skip(100);
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"skip\":100}");
        }

        [TestMethod]
        public void Filter_Fields()
        {
            Filter filter = new Filter();
            filter.Fields("PropertyName1", "PropertyName2", "PropertyName3");
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"fields\":{\"PropertyName1\":true,\"PropertyName2\":true,\"PropertyName3\":true}}");
        }

        [TestMethod]
        public void Filter_Order()
        {
            Filter filter = new Filter();
            filter.Order("PropertyName1", OrderKind.ASC);
            filter.Order("PropertyName2", OrderKind.ASC);
            string result = filter.Serialize();
            Assert.AreEqual(result, "{\"order\":[\"PropertyName1 ASC\",\"PropertyName2 ASC\"]}");
        }
    }
}
