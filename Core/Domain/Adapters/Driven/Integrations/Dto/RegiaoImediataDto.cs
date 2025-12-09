namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class RegiaoImediataDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = default!;

        public RegiaoIntermediariaDto RegiaoIntermediaria { get; set; } = default!;
    }
}
