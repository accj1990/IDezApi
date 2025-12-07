namespace IDezApi.Domain.Application.Dtos.Requests
{
    public class LogoutInputModel
    {
        public string Username { get; set; } = default!;
        public string IdToken { get; set; } = default!;
    }
}
