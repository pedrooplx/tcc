using TCC.Domain.Abstract;

namespace TCC.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
    }
}
