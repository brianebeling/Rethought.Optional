using System;

namespace Rethought.Optional.Unsafe
{
    public static class OptionUnsafeExtensions
    {
        public static T? ToNullable<T>(this Option<T> option) where T : struct
        {
            return option.HasValue ? option.Value : default(T?);
        }

        public static T ValueOrDefault<T>(this Option<T> option)
        {
            return option.HasValue ? option.Value : default;
        }

        public static T ValueOrFailure<T>(this Option<T> option)
        {
            if (option.HasValue)
            {
                return option.Value;
            }

            throw new OptionValueMissingException();
        }

        public static T ValueOrFailure<T>(this Option<T> option, string errorMessage)
        {
            if (option.HasValue)
            {
                return option.Value;
            }

            throw new OptionValueMissingException(errorMessage);
        }

        public static T ValueOrFailure<T>(this Option<T> option, Func<string> errorMessageFactory)
        {
            if (errorMessageFactory == null) throw new ArgumentNullException(nameof(errorMessageFactory));

            if (option.HasValue)
            {
                return option.Value;
            }

            throw new OptionValueMissingException(errorMessageFactory());
        }
    }
}