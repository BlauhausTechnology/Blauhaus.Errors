using System;

namespace Blauhaus.Errors.Extensions
{
    public static class ExceptionExtensions
    {
        public static bool IsErrorException(this Exception exception, Error error)
        {
            if (exception is ErrorException errorException)
            {
                if (errorException.Error == error)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsErrorException(this Exception exception)
        {
            return exception is ErrorException;
        }

        public static Error ToError(this Exception exception)
        {
            if (exception is ErrorException errorException)
            {
                return errorException.Error;
            }
            throw new ArgumentException("Given exception is not an ErrorException");
        }
    }
}