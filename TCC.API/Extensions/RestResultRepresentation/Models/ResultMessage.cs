using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TCC.API.Extensions.RestResultRepresentation.Models
{
    public class ResultMessage
    {
        public enum ResultMessageType
        {
            Warning,
            Errorm,
            Fatal,
            Critical
        }

        [JsonPropertyName("codigo")]
        [JsonProperty("codigo")]
        public string Code { get; set; }

        [JsonPropertyName("mensagem")]
        [JsonProperty("mensagem")]
        public string Message { get; set; }

        [JsonPropertyName("campos")]
        [JsonProperty("campos")]
        public List<ResultFieldMessage> FieldMessages { get; set; }

        [JsonPropertyName("tipo")]
        [JsonProperty("tipo")]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public ResultMessageType MessageType { get; set; }

        public ResultMessage() { }
        public ResultMessage(ResultMessageType messageType, string code, string message) : this(messageType, code, message, new List<ResultFieldMessage>()) { }
        public ResultMessage(ResultMessageType messageType, string code, string message, List<ResultFieldMessage> fieldMessages)
        {
            MessageType = messageType;
            Code = code;
            Message = message;
            FieldMessages = FieldMessages;
        }
    }
}
