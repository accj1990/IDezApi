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

            CreateMap<BuscarMunicipiosRequest, BuscarMunicipiosInputModel>();
            CreateMap<BuscarMunicipiosOutputModel, BuscarMunicipiosResponse>();


            CreateMap<PesquisarMunicipiosRequest, PesquisarMunicipiosInputModel>();
            CreateMap<PesquisarMunicipiosOutputModel, PesquisarMunicipiosResponse>();


        }
    }
}
