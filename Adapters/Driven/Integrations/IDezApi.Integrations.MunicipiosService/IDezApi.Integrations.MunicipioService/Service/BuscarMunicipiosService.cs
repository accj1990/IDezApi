using IDezApi.Integrations.MunicipioService.Interfaces;
using IDezApi.Integrations.MunicipiosService.Dto;

namespace IDezApi.Integrations.MunicipiosService.Service
{
    public class BuscarMunicipiosService : IBuscarMunicipiosService
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

    }
}
