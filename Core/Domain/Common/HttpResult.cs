namespace IDezApi.Domain.Common
{
    public class HttpResult<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

    }
}
