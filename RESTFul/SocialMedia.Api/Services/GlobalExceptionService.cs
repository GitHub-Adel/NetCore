using System;
using System.Net;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.CustomEntities;

namespace SocialMedia.Api.Services
{
    public class GlobalExceptionService:IGlobalExceptionService
    {        
        //se pone en el cuerpo de un catch de un try catch 
        public void CatchException(Exception ex)
        {
            //registramos error en un log.
            //le mostramos error al usuario.
            if(ex.GetType()==typeof(CustomException)){
                var a= (CustomException)ex;
               throw new CustomException(ex.Message,a.StatusCode,ex.InnerException);
            } 
            else { //si no es un eror personalizado, muestro un internal error por default
                throw new CustomException(ex.Message,HttpStatusCode.InternalServerError,ex.InnerException);
            } 
        }

        //dispara una exception personalizada, puesta por nosotros mismo
        //debe ser usada en un try catch
        public void CustomException(string message,HttpStatusCode statusCode=default(HttpStatusCode), Exception innerException=null){
            throw new CustomException(message,statusCode,innerException);
        }

    }
}
