using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IBuscarMunicipiosUseCase
    {

        public Task<List<MunicipioDto>> ExecuteAsync(string uf, CancellationToken cancellationToken);
    }
}
