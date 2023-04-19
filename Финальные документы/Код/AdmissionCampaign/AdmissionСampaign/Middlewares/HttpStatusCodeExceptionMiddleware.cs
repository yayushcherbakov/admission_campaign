using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AdmissionCampaign.API.Middlewares
{
    public class HttpStatusCodeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpStatusCodeExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                Console.WriteLine("start");
                await _next(context);
                Console.WriteLine("end");
            }
            catch (ApplicationException exception)
            {
                await HandleDefaultException(context, HttpStatusCode.BadRequest, exception);
            }
            catch (Exception)
            {
                await HandleDefaultException(context, HttpStatusCode.InternalServerError);
            }
        }

        public async Task HandleDefaultException(HttpContext context, HttpStatusCode httpStatusCode, Exception exception = null)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = @"application/json";

            var isCustomException = exception != null ? exception.GetType().IsSubclassOf(typeof(Exception)) : false;

            if (isCustomException)
            {
                await context.Response.WriteAsync(exception?.Message);
                return;
            }

            await context.Response.WriteAsync("Server is not responding. Try later");
        }
    }
}
