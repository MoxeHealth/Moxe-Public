namespace CodingInterview.Tests;

[TestClass]
public class ItemControllerTests : MockingTestBase<ItemController>
{
    private readonly Random _random = new();

    [TestMethod]
    public void Get()
    {
        var id = _random.Next();

        Assert.ThrowsException<NotImplementedException>(() => ClassUnderTest.Get(id));
    }
}
