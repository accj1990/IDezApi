namespace IDezApi.Domain.Adapters.Driven.Integrations.Dto
{
    public class MicrorregiaoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = default!;

        public MesorregiaoDto Mesorregiao { get; set; } = default!;
    }
}
