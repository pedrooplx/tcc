using System.Collections.Generic;
using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Atendimento : EntityBase
    {
        public List<Classificacao> Classificacao { get; set; }
        public Colaborador Colaborador { get; set; }
        public Cliente Cliente { get; set; }
    }
}
