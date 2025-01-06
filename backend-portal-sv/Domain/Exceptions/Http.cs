using System.Net;

namespace Domain.Exceptions
{
    public class Http
    {
        public class HttpResponseException : Exception
        {
            public HttpStatusCode StatusCode { get; }

            public HttpResponseException(HttpStatusCode statusCode, string message)
                : base(message)
            {
                StatusCode = statusCode;
            }
        }
    }
}
