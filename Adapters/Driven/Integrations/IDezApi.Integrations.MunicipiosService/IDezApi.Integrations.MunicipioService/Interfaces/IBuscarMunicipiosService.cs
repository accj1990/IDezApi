using IDezApi.Integrations.MunicipiosService.Dto;

namespace IDezApi.Integrations.MunicipioService.Interfaces
{
    public interface IBuscarMunicipiosService
    {

        Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf);

    }
}
