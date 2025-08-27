namespace CodingInterview.Tests;

[ExcludeFromCodeCoverage, TestClass]
public abstract class MockingTestBase<TType>
{
    protected static readonly AutoMock AutoMocker = AutoMock.GetLoose();
    protected static readonly TType ClassUnderTest = AutoMocker.Create<TType>();
}