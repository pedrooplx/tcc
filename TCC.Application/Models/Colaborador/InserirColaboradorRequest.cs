using TCC.Application.Models.Abstract;
using TCC.Domain.Enums;

namespace TCC.Application.Models.Colaborador
{
    public class InserirColaboradorRequest : BaseRequest
    {
        public int Funcional { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public long IdOrganizacao { get; set; }
    }
}
