using IDezApi.Domain.Common;

namespace IDezApi.Domain.Application.Dtos.Requests
{
    public class UpdateUserInputModel : BaseEntity
    {
        public string Password { get; set; } = default!;

        public string? Picture { get; set; } = default!;

    }
}
