
namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public static class TestErrors
    {
        public static readonly Error TestErrorOne = Error.Create("Description One");
        public static readonly Error TestErrorTwo = Error.Create("Description Two");
        public static Error TestErrorThree(string parameter) => Error.Create($"Description Three: {parameter}");
    }
}