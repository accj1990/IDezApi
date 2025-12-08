namespace IDezApi.MunicipiosService.Service
{
    public class MunicipiosService : IMunicipiosService
    {
        private readonly string _urlBrasilApi;
        private readonly string _urlIBGEApi;
        private readonly ILogger<MunicipiosService> _logger;
        private readonly IGenericClientHttp _genericClient;
        private readonly IConfiguration _configuration;
        private readonly int contador = 0;
        private Dictionary<string, List<MunicipiosDto>> _cache;
        private readonly List<string> estados = new()
        {
            "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA",
            "MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN",
            "RS","RO","RR","SC","SP","SE","TO"
        };

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

                var municipios = await _genericClient.GetAsync<List<MunicipiosDto>>(_urlBrasilApi + "/");

                return municipios;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<MunicipiosDto> PesquisarMunicipioAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
