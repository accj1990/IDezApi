using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations.MunicipiosServiceHttp
{
    public interface IBuscarMunicipiosService
    {
        public Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf);
    }
}
