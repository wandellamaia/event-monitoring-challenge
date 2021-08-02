using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Events.Infraestructure.Exception
{
    [ExcludeFromCodeCoverage]
    public static class MessageHelp{
        public static ErrorMessage Get(int code, string message = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest, object parameters = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return GetNonExistentMessage();
            }

            return new ErrorMessage()
            {
                Code = code,
                Description = message,
                StatusCode = statusCode,
                Parametes = parameters
            };
        }
        internal static int NonExistentMessageCode => -1;
        internal static string NonExistentMessageDescription => "Falha ao obter mensagem de erro.";
        internal static HttpStatusCode NonExistentMessageHttpStatusCode => HttpStatusCode.BadRequest;
        private static ErrorMessage GetNonExistentMessage() => new ErrorMessage()
        {
            Code = NonExistentMessageCode,
            Description = NonExistentMessageDescription,
            StatusCode = NonExistentMessageHttpStatusCode
        };
    }
}