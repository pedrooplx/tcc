using System;
using System.Globalization;
using TCC.Domain.Enums;

namespace TCC.Infra.Helpers.ExceptionsHelper
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }
        public AppException(ErrosEnum message) : base(message.ToString()) { }

        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
