namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class MunicipioIBGEDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = default!;

        public MicrorregiaoDto Microrregiao { get; set; } = default!;

        public RegiaoImediataDto RegiaoImediata { get; set; } = default!;
    }
}
