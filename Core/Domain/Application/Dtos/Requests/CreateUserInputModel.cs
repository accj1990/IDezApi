namespace IDezApi.Domain.Application.Dtos.Requests
{
    public class CreateUserInputModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public string? Picture { get; set; } = default!;

        public bool IsAdmin { get; set; } = false;
    }
}
