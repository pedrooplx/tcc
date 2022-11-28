using TCC.API.Extensions.Pagination;

namespace TCC.API.Extensions.RestResultRepresentation.Parameter
{
    public class PaginationParametersConfiguration<T> : PaginationParameters where T : class
    {
        public PaginationParametersConfiguration() : base() { }
        public PaginationParametersConfiguration(string defaultOrderBy) : base(defaultOrderBy) { }
        public PaginationParametersConfiguration(string defaultOrderBy, string defaultOrder, int defaultPageSize = 100, int maxPageSize = 1000) : base(defaultOrderBy, defaultOrder, defaultPageSize, maxPageSize) { }

        public Pagination.PaginationParameters AsRequest()
        {
            return new Pagination.PaginationParameters(this.Page, this.PageSize, AsEnum(this.Order), this.OrderBy);
        }

        private SortDirection AsEnum(string order)
        {
            switch (order?.ToUpper()?.Trim())
            {
                case "DESC":
                case "DESCENDING":
                    return SortDirection.Descending;
                default:
                    return SortDirection.Ascending;
            }
        }
    }
}
