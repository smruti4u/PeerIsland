using System.Collections.Generic;
using PeerIsland.Entities.ViewModel;

namespace PeerIsland.Common
{
    /// <summary>
    /// IEmployeeManager
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public interface IEmployeeManager<T> where T : Employee
    {
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>IEnumerable<T></returns>
        IEnumerable<T> AddEmployee(T employee);

        /// <summary>
        /// Check If Employee Exists
        /// </summary>
        /// <param name="Name">Name</param>
        /// <returns>bool</returns>
        bool CheckIfEmployeeExists(string Name);

        /// <summary>
        /// DeleteEmployee
        /// </summary>
        /// <param name="Name">Name</param>
        void DeleteEmployee(string Name);

        /// <summary>
        /// GetAllEmployees
        /// </summary>
        /// <returns>Type T</returns>
        IEnumerable<T> GetAllEmployees();
    }
}