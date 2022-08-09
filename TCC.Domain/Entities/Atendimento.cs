using System;
using System.ComponentModel.DataAnnotations;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Atendimento : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public Classificacao Classificacao { get; set; }
        public Colaborador Colaborador { get; set; }
        public Cliente Cliente { get; set; }
    }
}
