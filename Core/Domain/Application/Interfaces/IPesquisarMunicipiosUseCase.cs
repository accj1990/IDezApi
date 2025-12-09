using IDezApi.Domain.Application.Dtos.Responses;
namespace IDezApi.Domain.Application.Interfaces
{
    public interface IPesquisarMunicipiosUseCase
    {
        public Task<PesquisarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken);
    }
}
