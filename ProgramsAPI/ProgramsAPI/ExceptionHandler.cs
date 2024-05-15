﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProgramsAPI
{
    public sealed class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = new ProblemDetails();
            switch (exception)
            {
                case ArgumentNullException argumentNullException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Type = argumentNullException.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = argumentNullException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    _logger.LogError(argumentNullException, $"Exception occured : {argumentNullException.Message}");
                    break;
                default:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = exception.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = exception.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                    };
                    _logger.LogError(exception, $"Exception occured : {exception.Message}");
                    break;
            }
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
            return true;
        }
    }
}
