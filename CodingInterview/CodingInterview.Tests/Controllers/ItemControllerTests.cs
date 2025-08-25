using CodingInterview.Web;
using System;
using Xunit;

namespace CodingInterview.Tests
{
    public class ItemControllerTests : MockingTestBase<ItemController>
    {
        private readonly Random _random = new();

        [Fact]
        public void Get()
        {
            var id = _random.Next();

            Assert.Throws<NotImplementedException>(() => ClassUnderTest.Get(id));
        }
    }
}