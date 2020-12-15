using System;
using System.Net;

namespace SocialMedia.Api.CustomEntities
{
    public class CustomException: Exception
    {
        public HttpStatusCode StatusCode { get; }
        public CustomException(string message,HttpStatusCode statusCode=default(HttpStatusCode), Exception innerException=null) : base(message,innerException)
        {
            StatusCode = statusCode;
        }        
    }
}
