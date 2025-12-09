
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;

namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        //private readonly IBuscarMunicipiosService _municipiosService;

        public BuscarMunicipiosUseCase(/*IBuscarMunicipiosService municipiosService*/)
        {
            ///_municipiosService = municipiosService;
        }
        public Task<List<MunicipiosDto>> BuscarMunicipiosPorUfAsync(string uf) => throw new NotImplementedException();
    }
}
