namespace PeersIsland.DataAccess.Services
{
    /// <summary>
    /// Interface IXmlService
    /// </summary>
    public interface IXmlService
    {
        /// <summary>
        /// DeSerilize
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <returns>Type T</returns>
        T DeSerilize<T>();

        /// <summary>
        /// Serilize
        /// </summary>
        /// <typeparam name="T">Type T</typeparam>
        /// <param name="t">Type T</param>
        void Serilize<T>(T t);
    }
}