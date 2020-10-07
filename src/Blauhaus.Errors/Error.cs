using System;
using System.Runtime.CompilerServices;
using Blauhaus.Common.Utils.Attributes;

namespace Blauhaus.Errors
{
    [Preserve]
    public readonly struct Error : IEquatable<Error>
    {
        private Error(string code, string description)
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

        public static Error Deserialize(string serializedError)
        {
            var deserialized = serializedError.Split(new []{" ::: "}, StringSplitOptions.None);
            if (deserialized.Length != 2)
            {
                throw new ArgumentException($"Input {serializedError} is not a valid serialized Error");
            }
            return new Error(deserialized[0], deserialized[1]);
        }
        
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
    }
}