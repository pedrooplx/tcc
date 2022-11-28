using System;
using TCC.Domain.Entities.Abstract;
using TCC.Domain.Enums;

namespace TCC.Domain.Entities
{
    public class Classificacao : EntityBase
    {
        public long ColaboradorId { get; set; }
        public double Probabilidade { get; set; }
        public Emocoes Emocao { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}