using System;

namespace TCC.Domain.Abstract
{
    public class EntityBase : IAuditoria
    {
        public DateTime CriandoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
    }

    public interface IAuditoria
    {
        DateTime CriandoEm { get; set; }
        DateTime AlteradoEm { get; set; }
    }
}
