using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System;

namespace TCC.API.Extensions.RestResultRepresentation.Filters
{
    public class PaginationFilter : IActionFilter
    {
        public readonly Func<string, string> GetResolvedPropertyName;

        public PaginationFilter(IOptions<MvcNewtonsoftJsonOptions> mvcJsonOptions)
        {
            GetResolvedPropertyName = p => p;
            if (mvcJsonOptions?.Value?.SerializerSettings.ContractResolver is DefaultContractResolver dcr)
                GetResolvedPropertyName = dcr.GetResolvedPropertyName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
