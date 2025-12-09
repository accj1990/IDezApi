using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;


namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        private readonly IBuscarMunicipioService _buscarMunicipiosService;

        public BuscarMunicipiosUseCase(IBuscarMunicipioService buscarMunicipiosService)
        {
            _buscarMunicipiosService = buscarMunicipiosService;
        }
        public async Task<List<MunicipioDto>> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                return await _buscarMunicipiosService.BuscarMunicipiosPorUfAsync(uf, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar municípios por UF.", ex);
            }
        }
    }
}
