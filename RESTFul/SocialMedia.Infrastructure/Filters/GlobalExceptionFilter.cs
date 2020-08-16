using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exceptions;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType()==typeof(CustomException)){
                var exception = (CustomException)context.Exception;
                var validation=new{
                    Status=400,
                    Title="Bad Request",
                    Detail=exception.Message
                };

                var json=new{
                    Errors=new[]{validation}
                };

                context.Result=new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode=(int)HttpStatusCode.BadRequest;
                context.ExceptionHandled=true; //exception personalizada

            }
        }
    }
}
