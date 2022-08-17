using System;
using System.Collections.Generic;
using TCC.Domain.Entities.Abstract;

namespace TCC.Domain.Entities
{
    public class Atendimento : EntityBase
    {
        public List<Classificacao> Classificacao { get; set; }
        public Colaborador Colaborador { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime InicioAtendimento { get; set; }
        public DateTime FimAtendimento { get; set; }
    }
}
