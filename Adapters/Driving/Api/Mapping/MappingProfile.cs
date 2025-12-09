using AutoMapper;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Dtos.Response;
using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BuscarMunicipiosRequest, BuscarMunicipiosInput>();
            CreateMap<BuscarMunicipiosOutputModel, BuscarMunicipiosResponse>();


            CreateMap<PesquisarMunicipiosRequest, PesquisarMunicipiosInput>();
            CreateMap<PesquisarMunicipiosOutputModel, PesquisarMunicipiosResponse>();


        }
    }
}
