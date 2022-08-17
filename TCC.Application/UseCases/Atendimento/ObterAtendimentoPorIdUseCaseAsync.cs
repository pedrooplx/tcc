using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Atendimento;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Atendimento
{
    public class ObterAtendimentoPorIdUseCaseAsync : IUseCaseAsync<ObterAtendimentoPorIdRequest, ObterAtendimentoPorIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAtendimentoGateway _atendimentoGateway;

        public ObterAtendimentoPorIdUseCaseAsync(IMapper mapper, IAtendimentoGateway atendimentoGateway)
        {
            _mapper = mapper;
            _atendimentoGateway = atendimentoGateway;
        }

        public async Task<ObterAtendimentoPorIdResponse> ExecuteAsync(ObterAtendimentoPorIdRequest request)
        {
            var atendimento = await _atendimentoGateway.GetByIdAsync(request.Id);
            return _mapper.Map<ObterAtendimentoPorIdResponse>(atendimento);
        }
    }
}
