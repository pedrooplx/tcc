using System;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Classificacao : EntityBase
    {
        public double Probabilidade { get; set; }
        public string Emocao { get; set; }
        public Atendimento Atendimento { get; set; }
        public DateTime Horario { get; set; }
    }
}