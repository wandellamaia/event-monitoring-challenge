using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace Events.Infraestructure.Exception
{
    [ExcludeFromCodeCoverage]
    public class EventException: System.Exception
    {
        public ErrorMessage Error
        {
            get; set;
        }

        public int Code
        {
            get; set;
        }

        public EventException(ErrorMessage error)
        {
            this.Error = error;
            this.Code = error.Code;
        }

        public EventException(int code)
        {
            this.Error = MessageHelp.Get(code);
            this.Code = code;
        }

        public EventException(int code, HttpStatusCode statusCode, object parameters) : base(message: MessageHelp.Get(code, statusCode: statusCode, parameters: parameters).Description)
        {
            Error = MessageHelp.Get(code, statusCode: statusCode, parameters: parameters);
            Code = code;
        }

        public EventException()
        {
        }

        private EventException(string message)
            : base(message)
        {
        }

        private EventException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected EventException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public const string VALORPARAMETROINVALIDO = "Valor do parâmetro é inválido";
    }
}