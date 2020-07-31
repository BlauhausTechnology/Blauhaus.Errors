using CSharpFunctionalExtensions;

namespace Blauhaus.Errors.Extensions
{
    public static class ResultErrorExtensions
    {
        public static bool IsError(this Result result, Error error)
        {
            return result.IsFailure && result.Error.IsError(error);
        }

        public static bool IsError<T>(this Result<T> result, Error error)
        {
            return result.IsFailure && result.Error.IsError(error);
        }

    }
}