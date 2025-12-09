namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class RegiaoDto
    {
        public int Id { get; set; }

        public string Sigla { get; set; } = default!;

        public string Nome { get; set; } = default!;
    }
}
