using System.Text.Json.Serialization;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class MunicipiosDto
    {
        [JsonPropertyName("codigo_ibge")]
        public string Id { get; set; } = default!;

        [JsonPropertyName("nome")]
        public string Descricao { get; set; } = default!;
    }
}
