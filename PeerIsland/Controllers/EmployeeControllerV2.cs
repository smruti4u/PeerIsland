using Microsoft.AspNetCore.Mvc;
using PeerIsland.Common;
using PeerIsland.Entities.Extensions.Employees;
using PeerIsland.Entities.ViewModel;
using PeerIsland.Extensions;
using System;

namespace PeerIsland.Controllers
{
    /// <summary>
    /// Employee V2 Controller for Problem 2 For Extending XML Elements
    /// </summary>
    [Route("api/Employee/v2")]
    [ApiController]
    public class EmployeeV2Controller : ControllerBase
    {
        /// <summary>
        /// employeeManager
        /// </summary>
        private readonly IEmployeeManager<EmployeeExtensions> employeeManager;

        /// <summary>
        /// Constructor to Add Dependency Injenction
        /// </summary>
        /// <param name="employeeManager">employeeManager</param>
        public EmployeeV2Controller(IEmployeeManager<EmployeeExtensions> employeeManager)
        {
            this.employeeManager = employeeManager; 
        }

        /// <summary>
        /// Get All Employees For Problem2
        /// </summary>
        /// <returns>employees</returns>
        // GET api/values
        [HttpGet("GetAll")]
        public ActionResult<ApiResponse<EmployeeExtensions>> Get()
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
        public ActionResult<ApiResponse<EmployeeExtensions>> Add([FromBody]EmployeeExtensions employee)
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
        public ActionResult<ApiResponse<EmployeeExtensions>> Delete([FromRoute]string name)
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
