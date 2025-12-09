using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations.MunicipiosServiceHttp
{
    public interface IPesquisarMunicipiosService
    {
        public Task<List<MunicipiosIBGEDto>> BuscarMunicipiosPorUfAsync(string uf);
    }
}
