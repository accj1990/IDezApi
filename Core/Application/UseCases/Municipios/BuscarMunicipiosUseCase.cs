using IDezApi.Domain.Application.Interfaces;
using IDezApi.Domain.Application.Interfaces.Dto;

namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        //private readonly IBuscarMunicipiosService _municipiosService;

        public BuscarMunicipiosUseCase(/*IBuscarMunicipiosService municipiosService*/)
        {
            ///_municipiosService = municipiosService;
        }
        public Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf) => throw new NotImplementedException();
    }
}
