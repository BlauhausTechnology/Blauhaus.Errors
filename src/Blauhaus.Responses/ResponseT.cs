using System;
using System.Runtime.Serialization;
using Blauhaus.Errors;

namespace Blauhaus.Responses
{
    [Serializable, DataContract]
    public struct Response<T>
    { 
        public Response(bool isSuccess, Error error, T value)
        {
            IsSuccess = isSuccess;
            IsFailure = !IsSuccess;
            Error = error;
            Value = value;
        }

        [DataMember]
        public bool IsSuccess { get; private set; }
        [DataMember]
        public bool IsFailure { get; private set;}
        [DataMember]
        public Error Error { get; private set;}
        [DataMember]
        public T Value { get; private set;}
         
        public override string ToString()
        {
            return IsSuccess ? $"Success: {Value}" : Error.ToString();
        }
 
    }
}