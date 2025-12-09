namespace IDezApi.Integrations.MunicipiosService.Dto
{
    public class MunicipioIBGEDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = default!;

        [JsonPropertyName("microrregiao")]
        public MicrorregiaoDto Microrregiao { get; set; } = default!;

        [JsonPropertyName("regiao-imediata")]
        public RegiaoImediataDto RegiaoImediata { get; set; } = default!;
    }
}
