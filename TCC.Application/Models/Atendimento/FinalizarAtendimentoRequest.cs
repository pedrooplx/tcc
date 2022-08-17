using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Application.Models.Atendimento
{
    public class FinalizarAtendimentoRequest
    {
        public DateTime FimAtendimento { get; set; } = DateTime.Now;
    }
}
