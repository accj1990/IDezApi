namespace IDezApi.Api.Dtos.Base
{
    public class BaseGetAllRequest
    {
        public required int offset { get; set; } = 0;

        public required int limit { get; set; } = 100;
    }
}
