using System.Net;

namespace TCC.API.Extensions
{
    public static class StatusCodeExtensions
    {
        public static int Extrair<T>(T response)
        {
            if (response == null)
            {
                return (int)HttpStatusCode.NotFound;
            }

            return (int)HttpStatusCode.OK;
        }
    }
}
