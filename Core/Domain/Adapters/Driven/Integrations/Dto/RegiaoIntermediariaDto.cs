using System.Text.Json.Serialization;

namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class RegiaoIntermediariaDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;

        [JsonPropertyName("UF")]
        public UfDto Uf { get; set; } = default!;
    }
}
