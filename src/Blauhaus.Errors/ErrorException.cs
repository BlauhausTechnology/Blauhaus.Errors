﻿using System;

namespace Blauhaus.Errors
{


    /// <summary>
    /// For all those times (cough RX cough) when you have to return an exception as the error condition
    /// </summary>
    public class ErrorException : Exception
    {
        public ErrorException(Error error, string message = "") : base(message)
        {
            Error = error;
        }

        public Error Error { get; }
    }
}