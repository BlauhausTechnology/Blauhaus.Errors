using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blauhaus.Common.Utils.Attributes;
using Blauhaus.Common.Utils.Extensions;

namespace Blauhaus.Errors
{
    [Preserve]
    public readonly struct Error : IEquatable<Error>
    {
        [JsonConstructor]
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }

        public string Description { get; }

        /// <summary>
        /// Uses the caller's name as the Error Code.
        /// Use in static Error definition classes like so:
        /// public static Error MyError = Error.Create("My Description"); => Sets "MyError" as the error code
        /// </summary>
        public static Error Create(string errorDescription, [CallerMemberName] string errorCode = "")
        {
            return new Error(errorCode, errorDescription);
        }

        public static Error None { get; } = Create("No errors");
        public static Error Generic(string description) => new Error("Error", description);

        public static Error Deserialize(string serializedError)
        {
            var deserialized = serializedError.Split(new []{" ::: "}, StringSplitOptions.None);
            if (deserialized.Length != 2)
            {
                try
                {
                    return JsonSerializer.Deserialize<Error>(serializedError, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
                }
                catch (Exception e)
                {
                    throw new ArgumentException($"Input {serializedError} is not a valid serialized Error");
                }
            }
            return new Error(deserialized[0], deserialized[1]);
        }


        public static Error Undefined = Create("No definition exists for this error");
        public static Error Unexpected(string errorMessage = "") => Create(errorMessage == "" ? "An unexpected error has occured" : errorMessage);
        public static Error Cancelled = Create("The operation was cancelled");
        public static Error Timeout = Create("The operation was not completed in the alloted time");

        
        //Required value
        public static Error RequiredValue() => Create("A required parameter was not provided");
        public static Error RequiredValue(string propertyName) => Create($"A value is required for {propertyName}");
        public static Error RequiredValue<T>() => Create($"{typeof(T).Name} was missing a required value");
        public static Error RequiredValue<T>(Expression<Func<T, object>> property) => Create($"A value for the {property.ToPropertyName()} property on {typeof(T).Name} is required");

        //Invalid value
        public static Error InvalidValue() => Create("One of the given values was invalid");
        public static Error InvalidValue(string reason) => Create("An invalid value was given: " + reason);
        public static Error InvalidValue<T>() => Create($"The {typeof(T).Name} was invalid");
        public static Error InvalidValue<T>(Expression<Func<T, object>> property) => Create($"The value provided for {property.ToPropertyName()} on {typeof(T).Name} was invalid");
        public static Error InvalidValue<T>(Expression<Func<T, object>> property,  string reason) 
            => Create($"The value provided for {property.ToPropertyName()} on {typeof(T).Name} was invalid: {reason}");


        #region Equality
        
        public override string ToString()
        {
            return $"{Code} ::: {Description}";
        }


        public bool Equals(Error other)
        {
            return string.Equals(Code, other.Code, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is Error other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public static bool operator ==(Error left, Error right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Error left, Error right)
        {
            return !left.Equals(right);
        }



        #endregion
    }
}