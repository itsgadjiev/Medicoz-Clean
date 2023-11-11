using Medicoz.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Medicoz.MVC.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public GlobalExceptionHandlingMiddleware(ILoggerFactory loggerFactory, IWebHostEnvironment hostingEnvironment)
    {
        _logger = loggerFactory.CreateLogger<GlobalExceptionHandlingMiddleware>();
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        try
        {
            await next(context);
        }
        catch (ApplicationException ex)
        {
            await HandleCustomExceptionsAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleFailedRequestExceptionAsync(context, ex);
        }
    }

    private Task HandleCustomExceptionsAsync(HttpContext context, ApplicationException exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;
        var responseMessage = string.Empty;

        switch (exception)
        {
            case BadRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;

                break;
        }

        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)httpStatusCode;

        if (responseMessage == string.Empty)
            responseMessage = JsonSerializer.Serialize(exception.Message);

        return context.Response.WriteAsync(responseMessage);
    }

    private async Task HandleFailedRequestExceptionAsync(HttpContext context, Exception exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;
        var responseMessage = string.Empty;

        if (_hostingEnvironment.IsProduction())
        {
            _logger.LogCritical("Internal server error happened.", exception);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            responseMessage = JsonSerializer.Serialize("Internal server error happened.");
        }
        else
        {
            _logger.LogCritical(responseMessage);
            context.Response.ContentType = MediaTypeNames.Text.Plain;
            responseMessage = GetFailedRequestMessage(context, exception);
        }

        context.Response.StatusCode = (int)httpStatusCode;
        await context.Response.WriteAsync(responseMessage);
    }

    private string GetFailedRequestMessage(HttpContext context, Exception exception)
    {
        StringBuilder messageBuilder = new StringBuilder();
        messageBuilder.AppendLine("Failed Request");
        messageBuilder.AppendLine($"\tSchema: {context.Request?.Scheme}");
        messageBuilder.AppendLine($"\tHost: {context.Request?.Host}");
        messageBuilder.AppendLine($"\tUser: {context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous"}");
        messageBuilder.AppendLine($"\tMethod: {context.Request?.Method}");
        messageBuilder.AppendLine($"\tPath: {context.Request?.Path}");
        messageBuilder.AppendLine($"\tQueryString: {context.Request?.QueryString}");
        messageBuilder.AppendLine($"\tErrorMessage: {exception.Message}");
        messageBuilder.AppendLine("\tStacktrace:");

        if (exception.StackTrace != null)
        {
            string[] stackTraceLines = exception.StackTrace.Split('\n');
            foreach (string line in stackTraceLines)
            {
                messageBuilder.AppendLine(line);
            }
        }

        if (exception.InnerException != null)
        {
            var separator = new string('=', 150);
            messageBuilder.AppendLine(separator);
            messageBuilder.AppendLine($"\tInnerException's ErrorMessage: {exception.InnerException.Message}");
            messageBuilder.AppendLine("\tInnerException's Stacktrace:");

            if (exception.InnerException.StackTrace != null)
            {
                string[] innerStackTraceLines = exception.InnerException.StackTrace.Split('\n');
                foreach (string line in innerStackTraceLines)
                {
                    messageBuilder.AppendLine(line);
                }
            }
        }

        return messageBuilder.ToString();
    }
}
