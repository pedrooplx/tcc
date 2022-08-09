using System;
using System.ComponentModel.DataAnnotations;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Cliente : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public int Cpf { get; set; }
        public string Nome { get; set; }
    }
}
