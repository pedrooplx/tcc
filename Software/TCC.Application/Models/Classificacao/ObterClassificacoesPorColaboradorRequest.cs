using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacoesPorColaboradorRequest
    {
        [Required]
        public int FuncionalColaborador { get; set; }

        public ObterClassificacoesPorColaboradorRequest(int funcionalColaborador)
        {
            FuncionalColaborador = funcionalColaborador;
        }
    }
}
