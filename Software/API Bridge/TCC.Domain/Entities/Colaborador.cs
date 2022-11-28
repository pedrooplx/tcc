using System.Collections.Generic;
using TCC.Domain.Entities.Abstract;
using TCC.Domain.Enums;

namespace TCC.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        public long OrganizacaoId { get; set; }
        public int Funcional { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public Organizacao Organizacao { get; set; }
        public IEnumerable<Classificacao> Classificacoes { get; set; }
    }
}