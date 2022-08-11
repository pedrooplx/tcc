using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Domain.Abstract
{
    public abstract class EntityBase : IAuditoria
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CriandoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
    }

    public interface IAuditoria
    {
        DateTime CriandoEm { get; set; }
        DateTime AlteradoEm { get; set; }
    }
}