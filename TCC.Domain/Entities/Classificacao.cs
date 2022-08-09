using System;
using System.ComponentModel.DataAnnotations;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Classificacao : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public double Probabilidade { get; set; }
        public string Emocao { get; set; }
        public Atendimento Atendimento { get; set; }
    }
}
