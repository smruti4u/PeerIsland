using PeerIsland.Entities.ViewModel;
using System.Collections.Generic;

namespace PeersIsland.DataAccess.Repositories
{
    /// <summary>
    /// Generic Repository For reading Wrirting Employee enitity to XML File
    /// </summary>
    /// <typeparam name="T">The Type</typeparam>
    public class EmployeeRepository<T> : IEmployeeRepository<T> where T : Employee
    {
        /// <summary>
        /// employeedbContext
        /// </summary>
        private readonly IEmployeeDbContext<T> employeedbContext;

        /// <summary>
        /// EmployeeRepository
        /// </summary>
        /// <param name="employeedbContext">employeedbContext</param>
        public EmployeeRepository(IEmployeeDbContext<T> employeedbContext)
        {
            this.employeedbContext = employeedbContext;
        }

        /// <summary>
        /// GetEmployees
        /// </summary>
        /// <returns> IEnumerable<T></returns>
        public IEnumerable<T> GetEmployees()
        {
            return employeedbContext.employees;
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Type T</returns>
        public T AddEmployee(T employee)
        {
            employeedbContext.employees.Add(employee);
            this.SaveEmployee();
            return employee;
        }

        /// <summary>
        /// DeleteEmployee
        /// </summary>
        /// <param name="employee">employee</param>
        /// <returns>Type T</returns>
        public T DeleteEmployee(T employee)
        {
            employeedbContext.employees.Remove(employee);
            this.SaveEmployee();
            return employee;
        }

        /// <summary>
        /// SaveEmployee
        /// </summary>
        public void SaveEmployee()
        {
            Employees<T> employees = new Employees<T>();
            employees.Employee = employeedbContext.employees;
            employeedbContext.Save(employees);
        }
    }
}
