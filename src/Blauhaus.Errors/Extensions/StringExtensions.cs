using System;
using System.Linq.Expressions;
using System.Text.Json;

namespace Blauhaus.Errors.Extensions
{
    
    public static class StringExtensions
    {
        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        public static bool IsError(this string serializedError, Error expectedError)
        {
            return serializedError.IsError() &&
                   Error.Deserialize(serializedError).Equals(expectedError);
        }

        public static bool IsError(this string serializedError, Error expectedError, out Error error)
        {
            return serializedError.IsError(out error) && error.Equals(expectedError);
        }

        public static bool IsError(this string serializedError)
        {
            return serializedError.Contains(" ::: ");
        }

        public static bool IsError(this string serializedError, out Error error)
        {
            if (serializedError.Contains(" ::: "))
            {
                error = serializedError.ToError();
                return error !=null && !string.IsNullOrEmpty(error.Code);
            }
            try
            {
                error = JsonSerializer.Deserialize<Error>(serializedError, _serializerOptions);
                return error != null && !string.IsNullOrEmpty(error.Code);
            }
            catch (Exception e)
            {
                error = default;
                return false;
            }
        }
 
        public static Error ToError(this string serializedError)
        {
            return Error.Deserialize(serializedError);
        }

    }
}