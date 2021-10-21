using Autofac.Extras.Moq;
using System.Diagnostics.CodeAnalysis;

namespace CodingInterview.Tests
{
    [ExcludeFromCodeCoverage]
    public abstract class MockingTestBase<TType>
    {
        protected static readonly AutoMock AutoMocker = AutoMock.GetLoose();
        protected static readonly TType ClassUnderTest = AutoMocker.Create<TType>();
    }
}