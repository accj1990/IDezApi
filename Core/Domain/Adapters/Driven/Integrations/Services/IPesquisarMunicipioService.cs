using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Services
{
    public interface IPesquisarMunicipioService
    {
        Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf, CancellationToken cancellationToken);
    }
}
