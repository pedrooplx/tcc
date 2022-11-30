using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TCC.Domain.Gateways.Services
{
    public interface IConsultarIAGateway
    {
        Task<List<Tuple<string, double>>> ObterAnalise(string image);
    }
}