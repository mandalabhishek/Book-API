using Moq;
using NUnit.Framework;
using API.Ajmera.Context;

namespace API.Ajmera.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IDbBookContext>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}