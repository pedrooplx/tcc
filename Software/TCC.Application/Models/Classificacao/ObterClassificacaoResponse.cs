using System;
using System.Collections.Generic;
using System.Text;
using TCC.Domain.Enums;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacaoResponse
    {
        public double Probabilidade { get; set; }
        public Emocoes Emocao { get; set; }
    }
}