using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Blauhaus.Common.Utils.Attributes;

namespace Blauhaus.Errors
{
    [Preserve, DataContract]
    public struct Error : IEquatable<Error>
    {
        private Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        [DataMember]
        public string Code { get; private set; }

        [DataMember]
        public string Description { get; private set; }


        /// <summary>
        /// Uses the caller's name as the Error Code.
        /// Use in static Error definition classes like so:
        /// public static Error MyError = Error.Create("My Description"); => Sets "MyError" as the error code
        /// </summary>
        public static Error Create(string errorDescription, [CallerMemberName] string errorCode = "")
        {
            return new Error(errorCode, errorDescription);
        }

        public static Error None { get; } = Error.Create("The operation succeeded. there is no Error");

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