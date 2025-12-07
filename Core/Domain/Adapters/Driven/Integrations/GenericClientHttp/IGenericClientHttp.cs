using IDezApi.Domain.Common;

namespace IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp
{
    public interface IGenericClientHttp
    {
        Task<HttpResult<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
        Task<HttpResult<T>> PostAsync<T>(string url, object body, Dictionary<string, string>? headers = null);

        Task<T?> PostFormAsync<T>(string url, IDictionary<string, string> formData, CancellationToken cancellationToken = default);

        Task<HttpResult<T>> PutAsync<T>(string url, object body, Dictionary<string, string>? headers = null);
        Task<HttpResult<T>> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null);
    }
}
