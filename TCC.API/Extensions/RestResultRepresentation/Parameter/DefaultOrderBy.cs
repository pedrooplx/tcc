using System;

namespace TCC.API.Extensions.RestResultRepresentation.Parameter
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DefaultOrderBy : Attribute
    {
        public DefaultOrderBy()
        {
        }
    }
}
