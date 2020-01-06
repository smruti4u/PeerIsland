namespace PeerIsland.Entities.ViewModel
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Employees.
    /// </summary>
     [XmlRoot("employees")]
    public class Employees<T>
    {
        /// <summary>
        /// Employee.
        /// </summary>
        [XmlElement("employee")]
        public List<T> Employee =  new List<T>();
    }
}
