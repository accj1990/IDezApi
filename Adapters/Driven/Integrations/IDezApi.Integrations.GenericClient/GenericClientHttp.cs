using System.Net.Http.Json;
using System.Text.Json;

using HtmlAgilityPack;

using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;
using IDezApi.Domain.Common;

namespace IDezApi.Integrations.GenericClient
{
    public class GenericClientHttp : IGenericClientHttp
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        //private readonly bool _acceptJson = default!;

        public GenericClientHttp(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClient(Dictionary<string, string>? headers)
        {
            var client = _httpClientFactory.CreateClient("DefaultClient");

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(header.Key))
                        client.DefaultRequestHeaders.Remove(header.Key);

                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            return client;
        }
        public async Task<HttpResult<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                var client = CreateClient(headers);
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                return new HttpResult<T>
                {
                    Success = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(content) : default,
                    ErrorMessage = response.IsSuccessStatusCode ? null : content,
                    StatusCode = ( int )response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new HttpResult<T> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<HttpResult<T>> PostAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
        {
            try
            {
                var client = CreateClient(headers);
                var response = await client.PostAsJsonAsync(url, body);
                var content = await response.Content.ReadAsStringAsync();

                return new HttpResult<T>
                {
                    Success = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(content) : default,
                    ErrorMessage = response.IsSuccessStatusCode ? null : content,
                    StatusCode = ( int )response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new HttpResult<T> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<T?> PostFormAsync<T>(string url, IDictionary<string, string> formData, CancellationToken cancellationToken = default)
        {
            var client = CreateClient(null);
            using var content = new FormUrlEncodedContent(formData);

            var response = await client.PostAsync(url, content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new HttpRequestException($"Erro na requisição POST para {url}. StatusCode: {response.StatusCode}. Conteúdo: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

            if (responseContent.TrimStart().StartsWith('<'))
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(responseContent);

                object text = doc.DocumentNode.InnerText.Trim();
                return ( T )text;
            }


            var result = JsonSerializer.Deserialize<T>(responseContent, _jsonOptions);


            return result;
        }

        public async Task<HttpResult<T>> PutAsync<T>(string url, object body, Dictionary<string, string>? headers = null)
        {
            try
            {
                var client = CreateClient(headers);
                var response = await client.PutAsJsonAsync(url, body);
                var content = await response.Content.ReadAsStringAsync();

                return new HttpResult<T>
                {
                    Success = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(content) : default,
                    ErrorMessage = response.IsSuccessStatusCode ? null : content,
                    StatusCode = ( int )response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new HttpResult<T> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<HttpResult<T>> DeleteAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                var client = CreateClient(headers);
                var response = await client.DeleteAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                return new HttpResult<T>
                {
                    Success = response.IsSuccessStatusCode,
                    Data = response.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(content) : default,
                    ErrorMessage = response.IsSuccessStatusCode ? null : content,
                    StatusCode = ( int )response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new HttpResult<T> { Success = false, ErrorMessage = ex.Message };
            }
        }

    }

}
