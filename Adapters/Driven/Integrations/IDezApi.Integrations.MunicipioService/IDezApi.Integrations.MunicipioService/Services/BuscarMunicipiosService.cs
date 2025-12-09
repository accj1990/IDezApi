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
        private readonly string _urlIBGEApi;
        private readonly ILogger<BuscarMunicipiosService> _logger;
        private readonly IGenericClientHttp _genericClient;
        private readonly IConfiguration _configuration;
        private readonly int contador = 0;
        private Dictionary<string, List<MunicipioDto>> _cache;
        private readonly List<string> estados = new()
        {
            "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA",
            "MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN",
            "RS","RO","RR","SC","SP","SE","TO"
        };

        public BuscarMunicipiosService(IConfiguration configuration,
            ILogger<BuscarMunicipiosService> logger,
            IGenericClientHttp genericClient)
        {
            _configuration = configuration;
            _logger = logger;
            _genericClient = genericClient;
            _urlBrasilApi = _configuration["Municipios:urlBrasilApi"]!;
            _urlIBGEApi = _configuration["Municipios:urlIBGEApi"]!;

        }


        public async Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf)
        {
            try
            {
                var url = string.Format(_urlBrasilApi, uf);
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
