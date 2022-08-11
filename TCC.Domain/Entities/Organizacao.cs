using System.Collections.Generic;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Organizacao : EntityBase
    {
        public string Nome { get; set; }
        public int Cnpj { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }
}
