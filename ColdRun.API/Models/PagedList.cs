namespace ColdRun.API.Models
{
    /// <summary>
    /// A paginated list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Items per page
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Number of total items
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Number of total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Paginated list of items
        /// </summary>
        public List<T> List { get; }

        public PagedList(List<T> items, int totalCount, int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            List = items;
        }
    }

}
