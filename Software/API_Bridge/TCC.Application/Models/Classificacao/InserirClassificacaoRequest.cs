using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TCC.Application.Models.Abstract;
using TCC.Domain.Enums;

namespace TCC.Application.Models.Classificacao
{
    public class InserirClassificacaoRequest : BaseRequest
    {
        [Required]
        public int FuncionalColaborador { get; set; }
        [Required]
        public string Imagem { get; set; }
        [JsonIgnore]
        public EmocoesEnum? Emocao { get; set; }
        [JsonIgnore]
        public double? Probabilidade { get; set; }
        [JsonIgnore]
        public long ColaboradorId { get; set; }
    }
}
