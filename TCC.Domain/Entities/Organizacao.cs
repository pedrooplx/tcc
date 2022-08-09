using System;
using System.ComponentModel.DataAnnotations;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Organizacao : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Cnpj { get; set; }
    }
}
