using System;
using TCC.Domain.Entities.Abstract;

namespace TCC.Domain.Entities
{
    public class Classificacao : EntityBase
    {
        public long ColaboradorId { get; set; }
        public double Probabilidade { get; set; }
        public string Emocao { get; set; }
        public DateTime Horario { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}