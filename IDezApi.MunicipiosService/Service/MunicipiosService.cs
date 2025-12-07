
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;
using IDezApi.Domain.Adapters.Driven.Integrations.MunicipiosService;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IDezApi.MunicipiosService.Service
{
    public class MunicipiosService : IMunicipiosService
    {
        private readonly string _urlBrasilApi;
        private readonly string _urlIBGEApi;
        private readonly ILogger<MunicipiosService> _logger;
        private readonly IGenericClientHttp _genericClient;
        private readonly IConfiguration _configuration;

        public MunicipiosService(IConfiguration configuration,
            ILogger<MunicipiosService> logger,
            IGenericClientHttp genericClient)
        {
            _configuration = configuration;
            _logger = logger;
            _genericClient = genericClient;
            _urlBrasilApi = _configuration["Municipios:urlBrasilApi"]!;
            _urlIBGEApi = _configuration["Municipios:urlIBGEApi"]!;

        }
        public async Task<List<MunicipiosDto>> BuscarMunicipiosAsync(CancellationToken cancellationToken)
        {
            try
            {

                _logger.LogInformation("Buscar municipios");

                var municipios = await _genericClient.GetAsync<List<MunicipiosDto>>(_urlBrasilApi);

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<MunicipiosDto> PesquisarMunicipioAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
