using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.Services;
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
        private readonly ICacheService _cacheService;

        public BuscarMunicipiosUseCase(ILogger<BuscarMunicipiosUseCase> logger, IBuscarMunicipioService buscarMunicipiosService, ICacheService cacheService)
        {
            _logger = logger;
            _buscarMunicipiosService = buscarMunicipiosService;
            _cacheService = cacheService;
        }
        public async Task<BuscarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                if (await _cacheService.GetAsync(uf) is null or false)
                {
                    var items = await _buscarMunicipiosService.BuscarMunicipiosPorUfAsync(uf, cancellationToken);

                    await _cacheService.AddAsync(uf, items);

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
                else
                {
                    var itemsCache = await _cacheService.GetAsync(uf);

                    var resposta = new BuscarMunicipiosOutputModel()
                    {
                        Data = new GetAllMunicipios
                        {
                            items = itemsCache as List<MunicipioDto> ?? new List<MunicipioDto>()
                        },
                        Message = PatternsMessages.MessageSucessUseCaseMunicipios,
                        IsSuccess = true
                    };

                    return resposta;
                }

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
