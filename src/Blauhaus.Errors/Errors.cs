using System;
using System.Linq.Expressions;
using Blauhaus.Common.Utils.Extensions;

namespace Blauhaus.Errors
{
    public static class Errors
    {
        public static Error Undefined = Error.Create("No definition exists for this error");
        public static Error Unexpected(string errorMessage = "") => Error.Create("An unexpected error has occured" + errorMessage == "" ? "" : ": " + errorMessage);
        public static Error Cancelled = Error.Create("The operation was cancelled");

        public static Error RequiredValue() => Error.Create("A required parameter was not provided");
        public static Error RequiredValue(string propertyName) => Error.Create($"A value is required for {propertyName}");
        public static Error RequiredValue<T>() => Error.Create($"{typeof(T).Name} was missing a required value");
        public static Error RequiredValue<T>(Expression<Func<T, object>> property) => Error.Create($"A value for the {property.ToPropertyName()} property on {typeof(T).Name} is required");

    }
}