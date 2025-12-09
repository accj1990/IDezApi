namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class UfDto
    {
        public int Id { get; set; }

        public string Sigla { get; set; } = default!;

        public string Nome { get; set; } = default!;

        public RegiaoDto Regiao { get; set; } = default!;
    }
}
