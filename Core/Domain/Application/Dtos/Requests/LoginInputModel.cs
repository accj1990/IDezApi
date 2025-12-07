namespace IDezApi.Domain.Application.Dtos.Requests
{
    public class LoginInputModel
    {
        public required string Username { get; set; } = default!;
        public required string Password { get; set; } = default!;
    }
}
