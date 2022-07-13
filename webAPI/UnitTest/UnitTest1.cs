using App.Common;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var aaa=  PBKDF2Helper.GetHashedPassword("123", "h3FEbSSAthfsaTWBEAtSspKTDIlckbZda60OeB5c");
            Assert.Pass();
        }
    }
}