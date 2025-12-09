using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IPesquisarMunicipiosUseCase
    {
        public Task<List<MunicipiosIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf);
    }
}
