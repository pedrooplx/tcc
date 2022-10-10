using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCC.Domain.Enums;

namespace TCC.Application.Models.Classificacao
{
    public class AnaliseClassificacaoRequest
    {
        [Required]
        public string Imagem { get; set; }
        [JsonIgnore]
        public Emocoes? Emocao { get; set; }
        [JsonIgnore]
        public double? Probabilidade { get; set; }
    }
}
