using PeerIsland.Entities.ViewModel;
using PeersIsland.DataAccess.Services;
using System.Collections.Generic;

namespace PeersIsland.DataAccess
{
    /// <summary>
    /// Employee Db Context.
    /// </summary>
    public class EmployeeDbContext<T> : IEmployeeDbContext<T> where T : Employee
    {
        /// <summary>
        /// The XML Service.
        /// </summary>
        private readonly IXmlService xmlService;

        /// <summary>
        /// Employee Db Context Constructor
        /// </summary>
        /// <param name="xmlService">The xml Service</param>
        public EmployeeDbContext(IXmlService xmlService)
        {
            this.xmlService = xmlService;
            this.employees = xmlService.DeSerilize<Employees<T>>().Employee;
        }

        /// <summary>
        /// Students
        /// </summary>
        public List<T> employees { get; set; }

        /// <summary>
        /// Employees
        /// </summary>
        /// <param name="employees">employees</param>
        public void Save(Employees<T> employees) => xmlService.Serilize<Employees<T>>(employees);

    }
}
