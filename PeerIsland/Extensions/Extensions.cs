using Microsoft.AspNetCore.Builder;
using PeerIsland.Entities.ViewModel;
using PeerIsland.Middlewire;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeerIsland.Extensions
{
    /// <summary>
    /// Needed Extension Methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// CustumErrorHandling Extension Method
        /// </summary>
        /// <param name="builder">The ApplicationBuilder</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseCustumErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleWire>();
        }

        /// <summary>
        /// ToApiResponse Extnesion Method
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <param name="employees">employees</param>
        /// <returns>ApiResponse Object</returns>
        public static ApiResponse<T> ToApiResponse<T>(this IEnumerable<T> employees) where T  : Employee
        {
            return new ApiResponse<T>()
            {
                RequestId = Guid.NewGuid().ToString(),
                Employees = employees.ToList()
            };
        }
    }
}
