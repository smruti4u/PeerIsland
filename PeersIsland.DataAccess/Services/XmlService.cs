using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PeersIsland.DataAccess.Services
{
    /// <summary>
    /// Xml Service
    /// </summary>
    public class XmlService : IXmlService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// xmlFilePath
        /// </summary>
        private string xmlFilePath => configuration[Constants.XMLFilePath];

        /// <summary>
        /// XmlService
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public XmlService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// DeSerilize od Type T
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <returns>Type T</returns>
        public T DeSerilize<T>()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            T t = default(T);
            using (TextReader reader = new StreamReader(xmlFilePath))
            {
              t = (T)deserializer.Deserialize(reader);
            }

            return t;
                
        }

        /// <summary>
        /// SerilizeAsync
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <param name="t">Type T</param>
        public void Serilize<T>(T t)
        {
            if(t ==  null)
                throw new System.ArgumentNullException(nameof(t));

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(xmlFilePath, false, Encoding.UTF8))
            {
                serializer.Serialize(writer, t);
            };            
        }
    }
}
