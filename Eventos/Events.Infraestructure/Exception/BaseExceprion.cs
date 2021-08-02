using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Events.Infraestructure.Exception
{
    [ExcludeFromCodeCoverage]
    public class BaseException: System.Exception
    {
        public BaseException()
            : base() { }

        public BaseException(string message)
            : base(message) { }

        public BaseException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public BaseException(string message, System.Exception innerException)
            : base(message, innerException) { }

        public BaseException(string format, System.Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}