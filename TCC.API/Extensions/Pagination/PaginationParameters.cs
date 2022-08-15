namespace TCC.API.Extensions.Pagination
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class PaginationParameters
    {
        public int Page { get; }
        public int PageSize { get; }
        public SortDirection Direction { get; }
        public string OrderBy { get; }
        public PaginationParameters(int page, int pageSize, SortDirection direction, string orderBy)
        {
            Page = page;
            PageSize = pageSize;
            Direction = direction;
            OrderBy = orderBy;
        }
    }
}
