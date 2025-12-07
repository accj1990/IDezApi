using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.UpdateUserOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class UpdateUserOutputModel : BaseOutputModel<UpdateUserDto>
    {
        public UpdateUserOutputModel() : base()
        {
        }
        public UpdateUserDto userDto { get; set; } = default!;
        public class UpdateUserDto
        {
            public required string Id { get; set; } = default!;
            public required string Email { get; set; } = default!;
            public required string Password { get; set; } = default!;
            public string? Picture { get; set; }
        }
    }
}
