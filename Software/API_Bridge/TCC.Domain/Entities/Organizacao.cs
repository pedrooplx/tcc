using System.Collections.Generic;
using TCC.Domain.Entities.Abstract;

namespace TCC.Domain.Entities
{
    public class Organizacao : EntityBase
    {
        public string RazaoSocial { get; set; }
        public int Cnpj { get; set; }
        public double Patrimonio { get; set; }
        public string Area { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }
}
