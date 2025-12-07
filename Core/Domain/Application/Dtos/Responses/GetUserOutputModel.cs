using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.GetUserOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class GetUserOutputModel : BaseOutputModel<GetUserDto>
    {
        public GetUserOutputModel() : base()
        {
        }

        public GetUserDto userDto { get; set; } = default!;

        public class GetUserDto : BaseEntity
        {
            public required string Email { get; set; }
            public string? Picture { get; set; } = default!;
            public required bool IsAdmin { get; set; } = false;
        }
    }
}
