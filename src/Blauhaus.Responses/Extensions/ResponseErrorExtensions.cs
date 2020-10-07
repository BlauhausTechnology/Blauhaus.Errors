using Blauhaus.Errors;
using Blauhaus.Errors.Extensions;
using CSharpFunctionalExtensions;

namespace Blauhaus.Responses.Extensions
{
    public static class ResponseErrorExtensions
    {
        public static bool IsError(this Response result, Error error)
        {
            return result.IsFailure && result.Error.Equals(error);
        }

        public static bool IsError<T>(this Response<T> result, Error error)
        {
            return result.IsFailure && result.Error.Equals(error);
        }
    }
}