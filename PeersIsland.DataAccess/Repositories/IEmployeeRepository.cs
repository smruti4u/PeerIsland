using System.Collections.Generic;
using PeerIsland.Entities.ViewModel;

namespace PeersIsland.DataAccess.Repositories
{
    /// <summary>
    /// IEmployeeRepository
    /// </summary>
    /// <typeparam name="T">The Type T</typeparam>
    public interface IEmployeeRepository<T> where T : Employee
    {
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Type T</returns>
        T AddEmployee(T employee);

        /// <summary>
        /// DeleteEmployee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Type T</returns>
        T DeleteEmployee(T employee);

        /// <summary>
        /// GetEmployees
        /// </summary>
        /// <returns> IEnumerable<T></returns>
        IEnumerable<T> GetEmployees();

        /// <summary>
        /// SaveEmployee
        /// </summary>
        void SaveEmployee();
    }
}