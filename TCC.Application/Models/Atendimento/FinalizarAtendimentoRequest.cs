using System;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Atendimento
{
    public class FinalizarAtendimentoRequest : BaseRequest
    {
        public DateTime FimAtendimento { get; set; } = DateTime.Now;
    }
}
