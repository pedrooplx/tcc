using System;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Atendimento
{
    public class IniciarAtendimentoRequest : BaseRequest
    {
        public DateTime InicioAtendimento { get; set; } = DateTime.Now;
    }
}
