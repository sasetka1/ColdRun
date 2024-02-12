namespace ColdRun.API.Extension
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns paginated sub-set of list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNumber">1-based page number</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public static HashSet<T> Paginate<T>(this HashSet<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToHashSet();
        }
    }
}
