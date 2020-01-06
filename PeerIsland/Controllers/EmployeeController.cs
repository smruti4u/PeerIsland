using Microsoft.AspNetCore.Mvc;
using PeerIsland.Common;
using PeerIsland.Entities.ViewModel;
using PeerIsland.Extensions;
using System;

namespace PeerIsland.Controllers
{
    /// <summary>
    /// Employee V1 Controller for Problem 1 For Crud Operation On XML Elements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// employeeManager
        /// </summary>
        private readonly IEmployeeManager<Employee> employeeManager;

        /// <summary>
        /// Constructor to Add Dependency Injenction
        /// </summary>
        /// <param name="employeeManager">employeeManager</param>
        public EmployeeController(IEmployeeManager<Employee> employeeManager)
        {
            this.employeeManager = employeeManager; 
        }

        /// <summary>
        /// Get All Employees For Problem2
        /// </summary>
        /// <returns>employees</returns>
        // GET api/values
        [HttpGet("GetAll")]
        public ActionResult<ApiResponse<Employee>> Get()
        {
            var response = employeeManager.GetAllEmployees();
            return response.ToApiResponse();

        }

        /// <summary>
        /// Adds Employee
        /// </summary>
        /// <param name="employee">The Employee</param>
        /// <returns>Api Response</returns>
        [HttpPost("Add")]
        public ActionResult<ApiResponse<Employee>> Add([FromBody]Employee employee)
        {  
            if(employeeManager.CheckIfEmployeeExists(employee.Name))
            {
                return this.BadRequest($"Employee with name {employee.Name} Already Exists");
            }
            var response = employeeManager.AddEmployee(employee);
            return response.ToApiResponse();
        }

        /// <summary>
        /// Deletes Existing Employee
        /// </summary>
        /// <param name="name">Name Of the Employee</param>
        /// <returns>Api Response</returns>
        [HttpDelete("{name}")]
        public ActionResult<ApiResponse<Employee>> Delete([FromRoute]string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return this.BadRequest(new ApiErrorResponse() { ErrorMessage = "Name Is Required", ReferenceId = Guid.NewGuid().ToString() });
            }
            if (!employeeManager.CheckIfEmployeeExists(name))
            {
                return this.BadRequest(new ApiErrorResponse() { ErrorMessage = $"Employee with name { name } Does Not Exist", ReferenceId = Guid.NewGuid().ToString() });
            }

            employeeManager.DeleteEmployee(name);
            return this.Accepted();

        }
    }
}
