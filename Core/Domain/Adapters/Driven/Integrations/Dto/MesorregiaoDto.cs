namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class MesorregiaoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = default!;

        public UfDto Uf { get; set; } = default!;
    }
}
