namespace PeerIsland.Entities.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    /// <summary>
    /// Employee
    /// </summary>
    [XmlRoot("employee")]
    public class Employee : IValidatableObject
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName Is Required")]
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Designation
        /// </summary>
        [XmlElement("designation")]
        public string Designation { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        [XmlElement("age")]
        public int Age { get; set; }

        /// <summary>
        /// Validate Validation Errorrs
        /// </summary>
        /// <param name="validationContext">The validationContext.</param>
        /// <returns>IEnumerable<ValidationResult></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 0 || Age > 99)
            {
                yield return new ValidationResult(
                    $"Age Should be between  0-99 { Age }",
                    new[] { nameof(Age) });
            }
        }
    }
}
