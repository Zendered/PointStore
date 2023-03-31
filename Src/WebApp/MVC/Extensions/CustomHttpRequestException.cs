using System.Net;

namespace WebApp.MVC.Extensions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpRequestException()
        {

        }

        public CustomHttpRequestException(string message, Exception InnerException)
            : base(message, InnerException) { }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
