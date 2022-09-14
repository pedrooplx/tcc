using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TCC.API.Extensions.RestResultRepresentation.Parameter
{
    public class PaginationParameters
    {
        public readonly int maxPageSize;

        [BindNever]
        public string DefaultOrderBy { get; }

        [FromQuery(Name = "page")]
        public int Page { get; set; }

        [FromQuery(Name = "page_size")]
        public int PageSize { get; set; }

        [FromQuery(Name = "order")]
        public string Order { get; set; }

        [FromQuery(Name = "order_by")]
        public string OrderBy { get; set; }


        protected PaginationParameters(string defaultOrderBy = null, string defaultOrder = "ASCENDING", int defaultPageSize = 100, int maxPageSize = 1000)
        {
            Page = 1;
            Order = defaultOrderBy;
            PageSize = defaultPageSize;
            DefaultOrderBy = defaultOrderBy;

            this.maxPageSize = maxPageSize;
        }
    }
}
