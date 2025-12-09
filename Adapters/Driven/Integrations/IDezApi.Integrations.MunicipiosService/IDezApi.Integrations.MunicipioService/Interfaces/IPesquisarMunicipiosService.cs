using IDezApi.Integrations.MunicipiosService.Dto;

namespace IDezApi.Integrations.MunicipioService.Interfaces
{
    public interface IPesquisarMunicipiosService
    {
        public Task<List<MunicipioIBGEDto>> BuscarMunicipiosPorUfAsync(string uf);
    }
}
