using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Domain.Adapters.Driven.Integrations.MunicipiosService
{
    public interface IMunicipiosService
    {
        Task<List<MunicipiosDto>> BuscarMunicipiosAsync(CancellationToken cancellationToken);

        Task<MunicipiosDto> PesquisarMunicipioAsync(CancellationToken cancellationToken);
    }
}
