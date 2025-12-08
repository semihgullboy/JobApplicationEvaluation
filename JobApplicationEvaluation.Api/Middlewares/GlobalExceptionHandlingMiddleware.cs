using JobApplicationEvaluation.Core.Result;
using System.Net;
using System.Text.Json;

namespace JobApplicationEvaluation.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ErrorResult errorResult;
            switch (exception)
            {
                case ApplicationException ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResult = new ErrorResult("Application Exception Occured, please retry after sometime.", (int)HttpStatusCode.BadRequest);
                    break;
                case FileNotFoundException ex:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResult = new ErrorResult("The requested resource is not found.", (int)HttpStatusCode.NotFound);
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResult = new ErrorResult("Internal Server Error Occured, please retry after sometime.", (int)HttpStatusCode.InternalServerError);
                    break;

            }
            var exResult = JsonSerializer.Serialize(errorResult);
            await context.Response.WriteAsync(exResult);
        }
    }
}
