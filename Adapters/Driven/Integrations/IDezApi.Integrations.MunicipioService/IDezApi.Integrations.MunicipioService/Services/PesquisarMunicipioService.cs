
using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IDezApi.Integrations.MunicipioService.Services
{
    public class PesquisarMunicipioService : IPesquisarMunicipioService
    {
        private readonly string _urlIBGEApi;
        private readonly ILogger<PesquisarMunicipioService> _logger;
        private readonly IGenericClientHttp _genericClient;
        private readonly IConfiguration _configuration;

        public PesquisarMunicipioService(
            ILogger<PesquisarMunicipioService> logger,
            IGenericClientHttp genericClient,
            IConfiguration configuration)
        {
            _logger = logger;
            _genericClient = genericClient;
            _configuration = configuration;
            _urlIBGEApi = _configuration["Municipios:_urlIBGEApi"]!;
        }
        public async Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf)
        {
            try
            {
                var url = string.Format(_urlIBGEApi, uf);
                var response = await _genericClient.GetAsync<List<MunicipioIBGEDto>>(url);
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
