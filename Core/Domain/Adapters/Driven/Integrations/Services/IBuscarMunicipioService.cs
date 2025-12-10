using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Services
{
    public interface IBuscarMunicipioService
    {
        Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf, CancellationToken cancellationToken);
    }
}
