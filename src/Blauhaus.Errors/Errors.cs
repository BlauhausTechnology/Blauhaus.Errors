using System;
using System.Linq.Expressions;
using Blauhaus.Common.Utils.Extensions;

namespace Blauhaus.Errors
{
    [Obsolete("Use Error instead")]
    public static class Errors
    {
        public static Error Undefined = Error.Create("No definition exists for this error");
        public static Error Unexpected(string errorMessage = "") => Error.Create("An unexpected error has occured" + errorMessage == "" ? "" : ": " + errorMessage);
        public static Error Cancelled = Error.Create("The operation was cancelled");
        
        //Required value
        public static Error RequiredValue() => Error.Create("A required parameter was not provided");
        public static Error RequiredValue(string propertyName) => Error.Create($"A value is required for {propertyName}");
        public static Error RequiredValue<T>() => Error.Create($"{typeof(T).Name} was missing a required value");
        public static Error RequiredValue<T>(Expression<Func<T, object>> property) => Error.Create($"A value for the {property.ToPropertyName()} property on {typeof(T).Name} is required");

        //Invalid value
        public static Error InvalidValue() => Error.Create("One of the given values was invalid");
        public static Error InvalidValue(string reason) => Error.Create("An invalid value was given: " + reason);
        public static Error InvalidValue<T>() => Error.Create($"The {typeof(T).Name} was invalid");
        public static Error InvalidValue<T>(Expression<Func<T, object>> property) => Error.Create($"The value provided for {property.ToPropertyName()} on {typeof(T).Name} was invalid");
        public static Error InvalidValue<T>(Expression<Func<T, object>> property,  string reason) 
            => Error.Create($"The value provided for {property.ToPropertyName()} on {typeof(T).Name} was invalid: {reason}");
         

    }
     
}