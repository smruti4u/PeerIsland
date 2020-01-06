using System.Xml.Serialization;

namespace PeerIsland.Entities.Extensions.Employees
{
    /// <summary>
    /// Address
    /// </summary>
    [XmlRoot("address")]
    public class Address
    {
        /// <summary>
        /// DoorNo
        /// </summary>
        [XmlElement("doorNo")]
        public string DoorNo { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [XmlElement("street")]
        public string Street { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        [XmlElement("town")]
        public string Town { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }
    }
}