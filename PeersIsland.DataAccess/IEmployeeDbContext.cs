using PeerIsland.Entities.ViewModel;
using System.Collections.Generic;

namespace PeersIsland.DataAccess
{
    /// <summary>
    /// Generic DB Context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEmployeeDbContext<T> where T : Employee
    {
        /// <summary>
        /// List Of Employess
        /// </summary>
        List<T> employees { get; set; }

        /// <summary>
        /// Save Employees
        /// </summary>
        /// <param name="employees">employees</param>
        void Save(Employees<T> employees);
    }
}