using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PeerIsland.Entities.ViewModel;
using System;
using System.Threading.Tasks;

namespace PeerIsland.Middlewire
{
    /// <summary>
    /// ErrorHandlingMiddleWire
    /// </summary>
    public class ErrorHandlingMiddleWire
    {
        /// <summary>
        /// RequestDelegate.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// ErrorHandlingMiddleWire Constructor
        /// </summary>
        /// <param name="next">RequestDelegate</param>
        public ErrorHandlingMiddleWire(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Invoking Next Pipeline
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context).ConfigureAwait(false);
            }
            catch (Exception exe)
            {
                ApiErrorResponse errorResponse = new ApiErrorResponse()
                {
                    ReferenceId = Guid.NewGuid().ToString(),
                    ErrorMessage = exe?.Message,
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    var json = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(json).ConfigureAwait(false);
                }
            }
        }
    }
}
