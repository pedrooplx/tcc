using System;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models
{
    public class AnaliseRequest : BaseRequest
    {
        public Guid IdAtendimento { get; set; }
        public int FuncionalColaborador { get; set; }
        public int CpfCliente { get; set; }
        public string Imagem { get; set; }
    }
}