using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Enums;
using TCC.Domain.Gateways;
using TCC.Domain.Gateways.Services;
using TCC.Infra.Helpers.ExceptionsHelper;

namespace TCC.Application.UseCases.Classificacao
{
    public class InserirClassificacaoUseCaseAsync : IUseCaseAsync<InserirClassificacaoRequest, List<ObterClassificacaoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IClassificacaoGateway _classificacaoGateway;
        private readonly IColaboradorGateway _colaboradorGateway;
        private readonly IConsultarIAGateway _consultarIAGateway;

        public InserirClassificacaoUseCaseAsync(
            IMapper mapper,
            IClassificacaoGateway classificacaoGateway,
            IColaboradorGateway colaboradorGateway,
            IConsultarIAGateway consultarIAGateway)
        {
            _classificacaoGateway = classificacaoGateway;
            _mapper = mapper;
            _colaboradorGateway = colaboradorGateway;
            _consultarIAGateway = consultarIAGateway;
        }

        public async Task<List<ObterClassificacaoResponse>> ExecuteAsync(InserirClassificacaoRequest request)
        {
            var colaborador = await _colaboradorGateway.ObterColaboradorPorFuncional(request.FuncionalColaborador);

            if (colaborador != null)
            {
                var recognitionResult = await _consultarIAGateway.ObterAnalise(request.Imagem);

                if (recognitionResult != null)
                {
                    List<ObterClassificacaoResponse> retorno = new List<ObterClassificacaoResponse>();

                    foreach (var recognitions in recognitionResult)
                    {
                        request.Emocao = (EmocoesEnum)Enum.Parse(typeof(EmocoesEnum), recognitions.Item1);
                        request.Probabilidade = recognitions.Item2;
                        request.ColaboradorId = colaborador.Id;

                        var classificacao = _mapper.Map<Domain.Entities.Classificacao>(request);

                        await _classificacaoGateway.InsertAsync(classificacao);

                        retorno.Add(_mapper.Map<ObterClassificacaoResponse>(recognitions));
                    }

                    return retorno;
                }
                else
                {
                    await _classificacaoGateway.InsertAsync(new Domain.Entities.Classificacao() 
                    { 
                        Emocao = EmocoesEnum.undefined,
                        Probabilidade = 0,
                        ColaboradorId = colaborador.Id
                    });
                }
            }

            throw new AppException(ErrosEnum.COLABORADOR_NAO_CADASTRADO);
        }
    }
}
