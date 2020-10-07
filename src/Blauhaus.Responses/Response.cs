using System;
using System.Text.Json.Serialization;
using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    [Serializable]
    public readonly struct Response
    { 

        private static Response _success = new Response(true, Error.None);

        [JsonConstructor]
        public Response(bool isSuccess, bool isFailure, Error error)
        {
            IsSuccess = isSuccess;
            IsFailure = isFailure;
            Error = error;
        }

        public Response(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            IsFailure = !IsSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public Error Error { get; }

        public static Response Success() => _success;
        public static Response Failure(Error error)
        {
            return new Response(false, error);
        }

        public static Response<T> Failure<T>(Error error)
        {
            return new Response<T>(false, error, default);
        }

        public static Response<T> Success<T>(T value)
        {
            return new Response<T>(true, Error.None, value);
        }

        public override string ToString()
        {
            return IsSuccess ? "Success" : Error.ToString();
        }
    }
}