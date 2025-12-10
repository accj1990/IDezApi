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

        public PesquisarMunicipiosUseCase(ILogger<PesquisarMunicipiosUseCase> logger, IPesquisarMunicipioService pesquisarMunicipioService)
        {
            _logger = logger;
            _pesquisarMunicipioService = pesquisarMunicipioService;
        }
        public async Task<PesquisarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _pesquisarMunicipioService.PesquisarMunicipiosPorUfAsync(uf, cancellationToken);

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
