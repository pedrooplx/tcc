using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCC.Domain.Entities.Abstract
{
    public abstract class EntityBase : IAuditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid CriadoPor { get; set; }
        public DateTime CriandoEm { get; set; }
        public Guid AlteradoPor { get; set; }
        public DateTime AlteradoEm { get; set; }
    }

    public interface IAuditoria
    {
        public Guid CriadoPor { get; set; }
        DateTime CriandoEm { get; set; }
        public Guid AlteradoPor { get; set; }
        DateTime AlteradoEm { get; set; }
    }
}