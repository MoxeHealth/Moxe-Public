namespace CodingInterview.Tests;

[TestClass]
public class CustomerControllerTests : MockingTestBase<CustomerController>
{
    private readonly Random _random = new();

    [TestMethod]
    public void Get()
    {
        var id = _random.Next();

        Assert.ThrowsException<NotImplementedException>(() => ClassUnderTest.Get(id));
    }
}