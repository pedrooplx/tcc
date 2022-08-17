using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Classificacao
{
    public class InserirClassificacaoRequest
    {
        [Required]
        public Guid IdAtendimento { get; set; }
        [Required]
        public int FuncionalColaborador { get; set; }
        [Required]
        public int CpfCliente { get; set; }
        [Required]
        public string Imagem { get; set; }
        public DateTime Horario { get; set; } = DateTime.Now;
    }
}
