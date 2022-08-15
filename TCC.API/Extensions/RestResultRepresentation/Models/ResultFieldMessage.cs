using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TCC.API.Extensions.RestResultRepresentation.Models
{
    public class ResultFieldMessage
    {
        [JsonPropertyName("campo")]
        [JsonProperty("campo")]
        public string Field { get; set; }

        [JsonPropertyName("valor")]
        [JsonProperty("valor")]
        public string Value { get; set; }

        [JsonPropertyName("mensagem")]
        [JsonProperty("mensagem")]
        public string Message { get; set; }

        public ResultFieldMessage(string field, string value, string message)
        {
            Field = field;
            Value = value;
            Message = message;
        }
    }
}
