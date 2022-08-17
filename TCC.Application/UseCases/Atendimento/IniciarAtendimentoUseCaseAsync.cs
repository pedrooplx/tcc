using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Atendimento;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Atendimento
{
    public class IniciarAtendimentoUseCaseAsync : IUseCaseAsync<IniciarAtendimentoRequest>
    {
        private readonly IMapper _mapper;
        private readonly IAtendimentoGateway _atendimentoGateway;

        public IniciarAtendimentoUseCaseAsync(IMapper mapper, IAtendimentoGateway atendimentoGateway)
        {
            _mapper = mapper;
            _atendimentoGateway = atendimentoGateway;
        }

        public async Task ExecuteAsync(IniciarAtendimentoRequest request)
        {
            var atendimento = _mapper.Map<Domain.Entities.Atendimento>(request);

            await _atendimentoGateway.InsertAsync(atendimento);
        }
    }
}