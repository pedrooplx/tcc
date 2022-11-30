using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TCC.API.Extensions.RestResultRepresentation.Models
{
    public class Result
    {
        [JsonPropertyName("messages")]
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<ResultMessage> Messages { get; set; }

        public Result() { }
        public Result(List<ResultMessage> messages)
        {
            Messages = messages;
        }
    }

    public class Result<T> : Result
    {
        [JsonPropertyName("data")]
        [JsonProperty("data")]
        public T Data { get; set; }

        public Result(T data)
        {
            Data = data;
        }

        public Result(T data, List<ResultMessage> messages) : base(messages)
        {
            Data = data;
        }

        public Result()
        {
            Messages = new List<ResultMessage>();
        }
    }
}
