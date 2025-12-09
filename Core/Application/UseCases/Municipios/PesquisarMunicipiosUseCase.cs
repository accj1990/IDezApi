using IDezApi.Domain.Application.Interfaces;
using IDezApi.Domain.Application.Interfaces.Dto;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        PesquisarMunicipiosUseCase() { }
        public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf) => throw new NotImplementedException();
    }
}
