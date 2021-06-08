using Core.Utilities.HTTPStatusCodeMessages;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ErrorCatchMiddleware
{
    public class ErrorCatchMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorCatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            if (e.Message == StatusMessages.AuthenticationFailed)
            {
                message = e.Message;
                httpContext.Response.StatusCode = 401;
            }
            else if (e.Message == StatusMessages.AuthorizationDenied)
            {
                message = e.Message;
                httpContext.Response.StatusCode = 403;
            }
            else if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorResponse()
                {
                    StatusCode = 400,
                    Message = message,
                    Errors = errors
                }.ToString());

            }

            return httpContext.Response.WriteAsync(new ErrorResponse
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
