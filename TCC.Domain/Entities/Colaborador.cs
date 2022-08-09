using System;
using System.ComponentModel.DataAnnotations;
using TCC.Domain.Abstract;
using TCC.Domain.Enums;

namespace TCC.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public int Funcional { get; set; }
        public string Nome { get; set; }
        public Setor Setor { get; set; }
        public Organizacao Organizacao { get; set; }
    }
}
