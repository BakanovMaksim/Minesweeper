using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Minesweeper.API.Infrastructure;
using Minesweeper.API.Models.Responses;

using System.Net;
using System.Text.Json;

namespace Minesweeper.API.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequestExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            const string contentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Error = context.Exception.Message,
            };

            context.Result = new ContentResult
            {
                StatusCode = (int)GetHttpStatusCode(context.Exception),
                Content = JsonSerializer.Serialize(errorResponse),
                ContentType = contentType,
            };
        }

        public static HttpStatusCode GetHttpStatusCode(Exception exception)
        {
            return exception.GetType().Name switch
            {
                nameof(MinesweeperApplicationException) => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
