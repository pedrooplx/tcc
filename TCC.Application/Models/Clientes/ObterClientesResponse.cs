using System.Collections.Generic;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientesResponse
    {
        public IEnumerable<ObterClientePorIdResponse> Clientes { get; set; }
    }
}