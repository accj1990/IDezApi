using System.Text.Json.Serialization;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class UfDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; } = default!;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;

        [JsonPropertyName("regiao")]
        public RegiaoDto Regiao { get; set; } = default!;
    }
}
