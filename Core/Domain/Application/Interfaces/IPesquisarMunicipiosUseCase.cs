using IDezApi.Domain.Application.Interfaces.Dto;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IPesquisarMunicipiosUseCase
    {
        public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf);
    }
}
