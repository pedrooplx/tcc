using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TCC.API.Extensions.RestResultRepresentation.Models
{
    public class RestResult : JsonResult
    {
        public RestResult(int httpStatusCode) : base(new Result())
        {
            StatusCode = httpStatusCode;
        }

        public RestResult(List<ResultMessage> resultMessages, int httpStatusCode) : base(new Result(resultMessages))
        {
            StatusCode = httpStatusCode;
        }

        public RestResult(ResultMessage resultMessage, int httpStatusCode) : base(new Result(new List<ResultMessage> { resultMessage }))
        {
            StatusCode = httpStatusCode;
        }
    }

    public class RestResult<T> : JsonResult
    {
        public RestResult(T resultData, int httpStatusCode) : base(new Result<T>(resultData))
        {
            StatusCode = httpStatusCode;
        }

        public RestResult(T resultData, List<ResultMessage> resultMessages, int httpStatusCode) : base(new Result<T>(resultData, resultMessages))
        {
            StatusCode = httpStatusCode;
        }

        public RestResult(ResultMessage resultMessage, int httpStatusCode) : base(new Result<T>(default(T), new List<ResultMessage> { resultMessage }))
        {
            StatusCode = httpStatusCode;
        }

        public RestResult(List<ResultMessage> resultMessages, int httpStatusCode) : base(new Result<T>(default(T), resultMessages))
        {
            StatusCode = httpStatusCode;
        }
    }
}
