using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways.Services;

namespace TCC.Application.UseCases.Classificacao
{
    public class AnaliseClassificacaoUseCaseAsync : IUseCaseAsync<AnaliseClassificacaoRequest, List<ObterClassificacaoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultarIAGateway _consultarIAGateway;

        public AnaliseClassificacaoUseCaseAsync(
            IMapper mapper,
            IConsultarIAGateway consultarIAGateway)
        {
            _mapper = mapper;
            _consultarIAGateway = consultarIAGateway;
        }

        public async Task<List<ObterClassificacaoResponse>> ExecuteAsync(AnaliseClassificacaoRequest request)
        {
            if (request.Imagem != null)
            {
                var recognitionResult = await _consultarIAGateway.ObterAnalise(request.Imagem);

                if (recognitionResult != null)
                {
                    List<ObterClassificacaoResponse> retorno = new List<ObterClassificacaoResponse>();

                    foreach (var recognitions in recognitionResult)
                        retorno.Add(_mapper.Map<ObterClassificacaoResponse>(recognitions));

                    return retorno;
                }
            }

            return null;
        }
    }
}
