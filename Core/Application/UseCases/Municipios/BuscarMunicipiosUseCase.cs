using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;
//using IDezApi.Integrations.MunicipioService.Interfaces;


namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        //private readonly IBuscarMunicipiosService _municipiosService;

        public BuscarMunicipiosUseCase(/*IBuscarMunicipiosService municipiosService*/)
        {
            //_municipiosService = municipiosService;
        }
        public async Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf)
        {

            //return await _municipiosService.BuscarMunicipiosPorUfAsync(uf);

            return null;
        }
    }
}
