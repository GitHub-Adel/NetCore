using System;
using System.Net;

namespace SocialMedia.Api.Interfaces
{
    public interface IGlobalExceptionService    
    {
        void CatchException(Exception ex);
        void CustomException(string message,HttpStatusCode statusCode=default(HttpStatusCode), Exception innerException=null);
    }
}
