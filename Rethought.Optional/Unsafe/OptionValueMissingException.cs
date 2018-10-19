using System;

namespace Rethought.Optional.Unsafe
{
    public class OptionValueMissingException : Exception
    {
        internal OptionValueMissingException()
        {
        }

        internal OptionValueMissingException(string message)
            : base(message)
        {
        }

        protected OptionValueMissingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public OptionValueMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}