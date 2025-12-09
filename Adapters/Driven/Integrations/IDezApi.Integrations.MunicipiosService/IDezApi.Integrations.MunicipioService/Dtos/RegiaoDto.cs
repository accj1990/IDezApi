namespace IDezApi.Integrations.MunicipiosService.Dto
{
    public class RegiaoDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("sigla")]
        public string Sigla { get; set; } = default!;

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;
    }
}
