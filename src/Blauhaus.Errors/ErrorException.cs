using System;
using System.Runtime.InteropServices;
using Blauhaus.Common.Utils.Attributes;
using Blauhaus.Errors.Extensions;
using CSharpFunctionalExtensions;

namespace Blauhaus.Errors
{

    /// <summary>
    /// For all those times (cough RX cough) when you have to return an exception as the error condition
    /// </summary>
    [Preserve]
    public class ErrorException : Exception
    {
        public ErrorException(Error error, Exception innerException) : base(error.ToString(), innerException)
        {
            Error = error;
        }

        public ErrorException(Error error) : base(error.ToString())
        {
            Error = error;
        }

        public ErrorException(string serializedError) : base(serializedError)
        {
            Error = serializedError.IsError(out var error) ? error : Errors.Undefined;
        }
        
        public ErrorException(Result result) : base(result.Error)
        { 
            Error = result.Error.IsError(out var error) ? error : Errors.Undefined;
        }

        public Error Error { get; }
    }
}