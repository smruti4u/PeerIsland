using PeerIsland.Entities.ViewModel;
using System.Xml.Serialization;

namespace PeerIsland.Entities.Extensions.Employees
{
    /// <summary>
    /// EmployeeExtensions for Problem 2
    /// </summary>
    public class EmployeeExtensions : Employee
    {
        /// <summary>
        /// Address
        /// </summary>
        [XmlElement("address")]
        public Address Address { get; set; }
    }
}
