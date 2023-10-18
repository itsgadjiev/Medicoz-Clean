using Porto.Application.Contracts.Logging;

namespace Porto.WebApi.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly IAppLogger<GlobalExceptionHandlingMiddleware> _appLogger;

        public GlobalExceptionHandlingMiddleware(IAppLogger<GlobalExceptionHandlingMiddleware> appLogger)
        {
            _appLogger = appLogger;
        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
