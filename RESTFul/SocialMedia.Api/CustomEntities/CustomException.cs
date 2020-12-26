using System;
using System.Net;

namespace SocialMedia.Api.CustomEntities
{
    public class CustomException: Exception
    {
        public HttpStatusCode StatusCode { get; }
        //este constructor crea una exception
        public CustomException(string message,HttpStatusCode statusCode=default(HttpStatusCode), Exception innerException=null) : base(message,innerException)
        {
            StatusCode = statusCode;
        } 
    
        //este constructor disparará la exception al usuario
        public CustomException(Exception ex)
        {
           //registramos error en un log.
            //le mostramos error al usuario.
            if(ex.GetType()==typeof(CustomException)){
                var a= (CustomException)ex;
               throw new CustomException(ex.Message,a.StatusCode,ex.InnerException);
            } 
            else { //si no es un error personalizado, muestro un internal error por default
                throw new CustomException(ex.Message,HttpStatusCode.InternalServerError,ex.InnerException);
            } 
        }        
    }
}
