using System;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacaoResponse
    {
        public double Probabilidade { get; set; }
        public string Emocao { get; set; }
        public int FuncionalColaborador { get; set; }
        public DateTime HorarioCadastro { get; set; }
    }
}