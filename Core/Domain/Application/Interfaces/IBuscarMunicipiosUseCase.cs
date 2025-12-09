using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IBuscarMunicipiosUseCase
    {

        Task<BuscarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken);
    }
}
