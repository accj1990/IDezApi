using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Application.Dtos.Responses;
using IDezApi.Domain.Application.Interfaces;
using IDezApi.Domain.Enums;

using Microsoft.Extensions.Logging;

using static IDezApi.Domain.Application.Dtos.Responses.BuscarMunicipiosOutputModel;


namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        private readonly IBuscarMunicipioService _buscarMunicipiosService;
        private readonly ILogger<BuscarMunicipiosUseCase> _logger;

        public BuscarMunicipiosUseCase(ILogger<BuscarMunicipiosUseCase> logger, IBuscarMunicipioService buscarMunicipiosService)
        {
            _logger = logger;
            _buscarMunicipiosService = buscarMunicipiosService;
        }
        public async Task<BuscarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _buscarMunicipiosService.BuscarMunicipiosPorUfAsync(uf, cancellationToken);

                var resposta = new BuscarMunicipiosOutputModel()
                {
                    Data = new GetAllMunicipios
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
                return new BuscarMunicipiosOutputModel()
                {
                    Message = PatternsMessages.MessageErrorUseCaseMunicipios,
                    IsSuccess = false
                };
            }
        }
    }
}
