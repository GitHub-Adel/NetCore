using System;
using System.Collections.Generic;
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
