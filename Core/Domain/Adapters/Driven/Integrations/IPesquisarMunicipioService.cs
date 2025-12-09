using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations
{
    public interface IPesquisarMunicipioService
    {
        Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf);

    }
}
