using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

/*
 * Simple middleware to convert a catch a thrown exception and convert it into a string.
 * 
 */

namespace jarowa.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            //set the statuscode for our client ..
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //in the real world we could do some fancy json response here
            return context.Response.WriteAsync(ex.Message);
        }
    }
}
