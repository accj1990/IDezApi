using System.Text.Json.Serialization;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class RegiaoImediataDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;

        [JsonPropertyName("regiao-intermediaria")]
        public RegiaoIntermediariaDto RegiaoIntermediaria { get; set; } = default!;
    }
}
