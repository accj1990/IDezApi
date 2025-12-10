using IDezApi.Domain.Adapters.Driven.Integrations.Services;
using IDezApi.Domain.Application.Dtos.Responses;
using IDezApi.Domain.Application.Interfaces;
using IDezApi.Domain.Enums;

using Microsoft.Extensions.Logging;

using static IDezApi.Domain.Application.Dtos.Responses.PesquisarMunicipiosOutputModel;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        private readonly IPesquisarMunicipioService _pesquisarMunicipioService;
        private readonly ILogger<PesquisarMunicipiosUseCase> _logger;
        private readonly ICacheService _cacheService;

        public PesquisarMunicipiosUseCase(ILogger<PesquisarMunicipiosUseCase> logger, IPesquisarMunicipioService pesquisarMunicipioService, ICacheService cacheService)
        {
            _logger = logger;
            _pesquisarMunicipioService = pesquisarMunicipioService;
            _cacheService = cacheService;
        }
        public async Task<PesquisarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                if (await _cacheService.GetAsync(uf) is not null)
                {
                    var respostaCache = new PesquisarMunicipiosOutputModel()
                    {
                        Data = await _cacheService.GetAsync(uf) as GetAllMunicipiosIBGE,
                        Message = PatternsMessages.MessageSucessUseCaseMunicipios,
                        IsSuccess = true
                    };

                    return respostaCache;
                }

                var items = await _pesquisarMunicipioService.PesquisarMunicipiosPorUfAsync(uf, cancellationToken);

                await _cacheService.AddAsync(uf, items);

                var resposta = new PesquisarMunicipiosOutputModel()
                {
                    Data = new GetAllMunicipiosIBGE
                    {
                        items = items
                    },
                    Message = PatternsMessages.MessageSucessUseCaseMunicipios,
                    IsSuccess = true
                };

                return resposta;
            }
            catch (Exception)
            {
                return new PesquisarMunicipiosOutputModel()
                {
                    Message = PatternsMessages.MessageErrorUseCaseMunicipios,
                    IsSuccess = false
                };
            }
        }
    }
}
