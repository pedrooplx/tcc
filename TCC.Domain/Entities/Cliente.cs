using TCC.Domain.Entities.Abstract;

namespace TCC.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
