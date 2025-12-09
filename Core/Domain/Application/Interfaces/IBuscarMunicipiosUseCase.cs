using IDezApi.Domain.Application.Interfaces.Dto;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IBuscarMunicipiosUseCase
    {

        public Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf);
    }
}
