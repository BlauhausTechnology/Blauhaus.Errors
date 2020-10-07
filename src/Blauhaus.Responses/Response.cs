using System;
using System.Runtime.Serialization;
using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    [Serializable, DataContract]
    public struct Response
    { 
        private static Response _success = new Response(true, Error.None);

        public Response(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            IsFailure = !IsSuccess;
            Error = error;
        }

        [DataMember]
        public bool IsSuccess { get; private set; }
        [DataMember]
        public bool IsFailure { get; private set; }
        [DataMember]
        public Error Error { get; private set; }

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