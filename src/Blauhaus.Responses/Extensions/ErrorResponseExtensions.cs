using Blauhaus.Errors;
using CSharpFunctionalExtensions;

namespace Blauhaus.Responses.Extensions
{
    public static class ErrorResponseExtensions
    {
        public static Response ToResponse(this Error error)
        {
            return Response.Failure(error);
        }

        public static Response<T> ToResponse<T>(this Error error)
        {
            return Response.Failure<T>(error);
        }
    }
}