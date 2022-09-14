using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Organizacao
{
    public class AtualizarOrganizacaoUseCaseAsync : IUseCaseAsync<AtualizarOrganizacaoRequest>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizacaoGateway _organizacaoGateway;

        public AtualizarOrganizacaoUseCaseAsync(IMapper mapper, IOrganizacaoGateway organizacaoGateway)
        {
            _mapper = mapper;
            _organizacaoGateway = organizacaoGateway;
        }

        public async Task ExecuteAsync(AtualizarOrganizacaoRequest request)
        {
            var organizacao = await _organizacaoGateway.GetByIdAsync(request.Id);

            var organizacaoAtualizada = _mapper.Map(request, organizacao);

            await _organizacaoGateway.UpdateAsync(organizacaoAtualizada);
        }
    }
}