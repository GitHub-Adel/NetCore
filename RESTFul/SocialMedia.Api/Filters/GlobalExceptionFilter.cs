using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Api.CustomEntities;

namespace SocialMedia.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {        
        //recibe la exception y si es CustomException crea un objeto anonimo con las
        //con propiedades estandar que retornara en formato json.
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(CustomException))
            {
                var exception = (CustomException)context.Exception;
                var validation = new
                {
                    Status =exception.StatusCode,
                    Title = exception.StatusCode.ToString(),
                    Message = exception.Message,
                    InnerException=exception.InnerException?.Message,
                    StackTrace=exception.StackTrace.Split(Environment.NewLine.ToCharArray())[0]
                };

                var json=new Dictionary<string,object>(){{"Errors",validation}};

                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)exception.StatusCode;
                context.ExceptionHandled = true; //exception personalizada
            }

        }    
    
    }



}
