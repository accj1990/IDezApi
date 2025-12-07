namespace IDezApi.Domain.Adapters.Driving.Api.Mapping
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
