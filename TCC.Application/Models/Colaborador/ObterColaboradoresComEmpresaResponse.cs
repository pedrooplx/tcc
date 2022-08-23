using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Application.Models.Colaborador
{
    public class ObterColaboradoresComEmpresaResponse
    {
        public IEnumerable<ObterColaboradorComEmpresaPorIdResponse> Colaboradores { get; set; }
    }
}
