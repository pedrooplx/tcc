using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Classificacao
{
    public class InserirClassificacaoRequest : BaseRequest
    {
        [Required]
        public Guid IdAtendimento { get; set; }
        [Required]
        public int FuncionalColaborador { get; set; }
        [Required]
        public string Imagem { get; set; }
    }
}
