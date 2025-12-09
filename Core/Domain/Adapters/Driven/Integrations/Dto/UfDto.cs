using System.Text.Json.Serialization;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class UfDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("regiao")]
        public RegiaoDto Regiao { get; set; }
    }
}
