using System;
using System.Collections.Generic;

namespace PeerIsland.Entities.ViewModel
{
    /// <summary>
    /// ApiResponse
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    public class ApiResponse<T> where T  :  Employee
    {
        /// <summary>
        /// RequestId
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Employees
        /// </summary>
        public List<T> Employees { get; set; } = new List<T>();
    }
}
