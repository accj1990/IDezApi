using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        PesquisarMunicipiosUseCase() { }
        public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf) => throw new NotImplementedException();
    }
}
