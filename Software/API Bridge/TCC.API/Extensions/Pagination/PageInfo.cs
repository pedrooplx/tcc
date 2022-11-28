namespace TCC.API.Extensions.Pagination
{
    public class PageInfo : PaginationParameters
    {
        public int TotalPages { get; }
        public int TotalElements { get; }

        public PageInfo(PaginationParameters request, int totalPages, int totalElements): base(request.Page, request.PageSize, request.Direction, request.OrderBy)
        {
            TotalPages = totalPages;
            TotalElements = totalElements;
        }
    }
}
