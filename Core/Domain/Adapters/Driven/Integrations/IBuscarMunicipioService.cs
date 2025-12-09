using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations
{
    public interface IBuscarMunicipioService
    {
        Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf);

    }
}
