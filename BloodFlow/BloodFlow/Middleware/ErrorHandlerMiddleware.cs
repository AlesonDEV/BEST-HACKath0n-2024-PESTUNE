using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using BloodFlow.BuisnessLayer.Validation;

namespace BloodFlow.PresentaionLayer.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)GetErrorCode(error);
                var message = error.Message;
                var errorType = error.GetType().Name;

                var result = JsonSerializer.Serialize(new { error = errorType, message = message });
                await response.WriteAsync(result);
            }
        }

        private HttpStatusCode GetErrorCode(Exception error)
        {
            return error switch
            {
                ValidationException _ => HttpStatusCode.BadRequest,
                InvalidAddressException _ => HttpStatusCode.NotFound,
                ArgumentException _ => HttpStatusCode.BadRequest,
                HttpRequestException _ => HttpStatusCode.ServiceUnavailable,
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}
