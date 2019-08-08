using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Domain.Exceptions;

namespace Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                int code = ex is HttpException ? (ex as HttpException).StatusCode : 500;
                var json = JsonConvert.SerializeObject(new { Error = ex.Message });

                context.Response.Clear();
                context.Response.StatusCode = code;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }

    public static class ErrorHandlerMiddlewareExt
    {
        public static IApplicationBuilder UseCustomErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}