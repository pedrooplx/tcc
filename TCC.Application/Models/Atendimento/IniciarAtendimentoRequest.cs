using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Application.Models.Atendimento
{
    public class IniciarAtendimentoRequest
    {
        public DateTime InicioAtendimento { get; set; } = DateTime.Now;
    }
}
