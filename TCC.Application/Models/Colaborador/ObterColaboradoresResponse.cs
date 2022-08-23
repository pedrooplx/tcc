using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Application.Models.Colaborador
{
    public class ObterColaboradoresResponse
    {
        public IEnumerable<ObterColaboradorPorIdResponse> Colaboradores { get; set; }
    }
}
