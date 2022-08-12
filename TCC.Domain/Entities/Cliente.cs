using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public long Cpf { get; set; }
        public string Nome { get; set; }
    }
}
