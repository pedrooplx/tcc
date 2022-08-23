using TCC.Domain.Entities.Abstract;
using TCC.Domain.Enums;

namespace TCC.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        public int Funcional { get; set; }
        public string Nome { get; set; }
        public Setor Setor { get; set; }
        public Organizacao Organizacao { get; set; }
    }
}