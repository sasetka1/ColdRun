namespace ColdRun.API.Mappers
{
    /// <summary>
    /// Generic mapper from T object to TU object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    public interface IMapper<in T, out TU>
        where T : class
        where TU : class
    {
        /// <summary>
        /// Maps T object to TU object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TU Map(T obj);
    }

    /// <summary>
    /// Generic mapper from T object to TU object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    /// <typeparam name="U"></typeparam>
    public interface IMapper<in T, in U, out TU>
        where T : class
        where U : class
        where TU : class
    {
        /// <summary>
        /// Maps T object to TU object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nextObj"></param>
        /// <returns></returns>
        TU Map(T obj, U nextObj);
    }
}
