using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TCC.API.Extensions.RestResultRepresentation.Filters
{
    public class ResponseWithPagination : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return serviceProvider.GetRequiredService<PaginationFilter>();
        }
    }
}
