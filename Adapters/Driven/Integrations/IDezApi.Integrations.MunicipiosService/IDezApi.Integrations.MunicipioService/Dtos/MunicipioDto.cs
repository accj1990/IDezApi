namespace IDezApi.Integrations.MunicipiosService.Dto
{
    public class MunicipioDto
    {
        [JsonPropertyName("codigo_ibge")]
        public string Id { get; set; } = default!;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;
    }
}
