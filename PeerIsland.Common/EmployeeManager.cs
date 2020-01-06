using PeerIsland.Entities.ViewModel;
using PeersIsland.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PeerIsland.Common
{
    /// <summary>
    /// EmployeeManager.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        /// <summary>
        /// employeeRepository
        /// </summary>
        private readonly IEmployeeRepository<T> employeeRepository;

        /// <summary>
        /// EmployeeManager
        /// </summary>
        /// <param name="employeeRepository">employeeRepository</param>
        public EmployeeManager(IEmployeeRepository<T> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// GetAllEmployees
        /// </summary>
        /// <returns>Type T</returns>
        public IEnumerable<T> GetAllEmployees()
        {
            return  employeeRepository.GetEmployees();
        }

        /// <summary>
        /// Check If Employee Exists
        /// </summary>
        /// <param name="Name">Name</param>
        /// <returns>bool</returns>
        public bool CheckIfEmployeeExists(string Name)
        {
            return employeeRepository.GetEmployees().Where(x => x.Name.ToUpper(CultureInfo.InvariantCulture) == Name.ToUpper(CultureInfo.InvariantCulture)).Any();
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>IEnumerable<T></returns>
        public IEnumerable<T> AddEmployee(T employee)
        {
            List<T> employeeList = new List<T>();
            employeeList.Add(employeeRepository.AddEmployee(employee));
            return employeeList;
        }

        /// <summary>
        /// DeleteEmployee
        /// </summary>
        /// <param name="Name">Name</param>
        public void DeleteEmployee(string Name)
        {
            var employee = employeeRepository.GetEmployees().Where(x => x.Name.ToUpper(CultureInfo.InvariantCulture) == Name.ToUpper(CultureInfo.InvariantCulture)).FirstOrDefault();
            if (employee != null)
            {
                employeeRepository.DeleteEmployee(employee);
            }
        }
    }
}
