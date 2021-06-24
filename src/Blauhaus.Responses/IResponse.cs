using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    public interface IResponse
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        Error Error { get; }
    }

    public interface IResponse<out T> : IResponse
    {
        T Value { get; }
    }
}