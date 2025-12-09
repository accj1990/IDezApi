namespace IDezApi.Domain.Application.Interfaces.Dto
{
    public class UfDto
    {
        public int Id { get; set; }

        public string Sigla { get; set; } = default!;

        public string Nome { get; set; } = default!;

        public RegiaoDto Regiao { get; set; } = default!;
    }
}
