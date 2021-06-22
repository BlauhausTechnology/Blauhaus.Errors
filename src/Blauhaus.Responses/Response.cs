using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    [Serializable]
    public readonly struct Response
    { 
        private static Response _success = new Response(true, Error.None);
        private static Task<Response> _successTask = Task.FromResult(_success);

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
        public static Task<Response> SuccessTask() => _successTask;

        public static Response Failure(Error error)
        {
            return new Response(false, error);
        }
        public static Task<Response> FailureTask(Error error)
        {
            return Task.FromResult(new Response(false, error));
        }

        public static Response Failure(string errorMessage)
        {
            return new Response(false, Error.Generic(errorMessage));
        }

        public static Response<T> Failure<T>(Error error)
        {
            return new Response<T>(false, error, default);
        }
        public static Task<Response<T>> FailureTask<T>(Error error)
        {
            return Task.FromResult(new Response<T>(false, error, default));
        }
        
        public static Response<T> Failure<T>(string errorMessage)
        {
            return new Response<T>(false, Error.Generic(errorMessage), default);
        }

        public static Response<T> Success<T>(T value)
        {
            return new Response<T>(true, Error.None, value);
        }
        public static Task<Response<T>> SuccessTask<T>(T value)
        {
            return Task.FromResult(new Response<T>(true, Error.None, value));
        }

        public override string ToString()
        {
            return IsSuccess ? "Success" : Error.ToString();
        }
    }
}