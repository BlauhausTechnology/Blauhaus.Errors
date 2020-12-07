using System;
using System.Linq.Expressions;

namespace Blauhaus.Errors.Extensions
{
    public static class ValidationExtensions
    {
        
        public static string ThrowIfNullOrWhiteSpace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ErrorException(Errors.RequiredValue());

            return value;
        }

        public static string ThrowIfNullOrWhiteSpace<T>(this string value, Expression<Func<T, object>> property)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ErrorException(Errors.RequiredValue(property));

            return value;
        }

        public static Guid ThrowIfEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                throw new ErrorException(Errors.RequiredValue());

            return value;
        }

        public static Guid ThrowIfEmpty<T>(this Guid value, Expression<Func<T, object>> property)
        {
            if (value == Guid.Empty)
                throw new ErrorException(Errors.RequiredValue<T>(property));

            return value;
        }
    }
}