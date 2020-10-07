using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    [Serializable]
    public struct Response<T>
    { 

        [JsonConstructor]
        public Response(bool isSuccess, bool isFailure, Error error, T value)
        {
            IsSuccess = isSuccess;
            IsFailure = isFailure;
            Error = error;
            Value = value;
        }

        public Response(bool isSuccess, Error error, T value)
        {
            IsSuccess = isSuccess;
            IsFailure = !IsSuccess;
            Error = error;
            Value = value;
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public Error Error { get; }
        public T Value { get; }
         
        public override string ToString()
        {
            return IsSuccess ? $"Success: {Value}" : Error.ToString();
        }
 
    }
}