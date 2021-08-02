using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json.Serialization;

namespace Events.Infraestructure.Exception
{
    
    [ExcludeFromCodeCoverage]
    public class ErrorMessage
    {
        public int Code
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }

        public object Parametes
        {
            get; set;
        }

        [JsonIgnore]
        public HttpStatusCode StatusCode
        {
            get; set;
        }
    }
}