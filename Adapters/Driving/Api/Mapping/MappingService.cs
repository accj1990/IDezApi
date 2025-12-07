using AutoMapper;

using IDezApi.Domain.Adapters.Driving.Api.Mapping;

namespace IDezApi.Api.Mapping
{
    public class MapperService(IMapper mapper) : IMapperService
    {
        private readonly IMapper _mapper = mapper;

        public TDestination Map<TSource, TDestination>(TSource source) => _mapper.Map<TSource, TDestination>(source);
    }
}
