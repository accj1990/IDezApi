using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IDezApi.Integrations.MunicipioService.Services
{
    public class BuscarMunicipiosService : IBuscarMunicipioService
    {
        private readonly string _urlBrasilApi;
        private readonly ILogger<BuscarMunicipiosService> _logger;
        private readonly IGenericClientHttp _genericClient;
        private readonly IConfiguration _configuration;

        public BuscarMunicipiosService(IConfiguration configuration,
            ILogger<BuscarMunicipiosService> logger,
            IGenericClientHttp genericClient)
        {
            _configuration = configuration;
            _logger = logger;
            _genericClient = genericClient;
            _urlBrasilApi = _configuration["Municipios:urlBrasilApi"]!;
        }


        public async Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                var url = string.Format(_urlBrasilApi + uf, uf);
                var response = await _genericClient.GetAsync<List<MunicipioDto>>(url);
                if (response.Success && response.Data != null)
                {
                    return response.Data;
                }
                else
                {
                    _logger.LogError("Erro ao buscar municípios para a UF {Uf}: {ErrorMessage}", uf, response.ErrorMessage);
                    throw new Exception($"Erro ao buscar municípios para a UF {uf}: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exceção ao buscar municípios para a UF {Uf}", uf);
                throw;
            }
        }
    }
}
