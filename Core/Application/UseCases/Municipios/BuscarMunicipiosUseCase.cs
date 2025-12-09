using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;


namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        private readonly IBuscarMunicipioService _municipiosService;

        public BuscarMunicipiosUseCase(IBuscarMunicipioService municipiosService)
        {
            _municipiosService = municipiosService;
        }
        public async Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf)
        {

            return await _municipiosService.BuscarMunicipiosPorUfAsync(uf);

        }
    }
}
