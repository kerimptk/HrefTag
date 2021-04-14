using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace BaseCore.Middlewares
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { error = ex.Message, success = false }));
            }
            catch (Exception ex)
            {

            }
            //if (context.Response.StatusCode == 404) context.Response.Redirect($"/404");

        }

    }
}
