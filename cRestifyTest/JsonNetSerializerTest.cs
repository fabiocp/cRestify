using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cRestify;
using Should;

namespace cRestifyTest
{
    [TestClass]
    public class JsonNetSerializerTest
    {
        [TestMethod]
        public void TestSerializeSimpleObject()
        {
            var obj = new { value1 = "1", value2 = "2" };
            new JsonNetSerializer().Serialize(obj).ShouldEqual(@"{""value1"":""1"",""value2"":""2""}");
        }
    }
}
