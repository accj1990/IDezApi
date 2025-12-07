using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.CreateUserOutputModel;
namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class CreateUserOutputModel : BaseOutputModel<CreateUserDto>
    {
        public CreateUserOutputModel() : base()
        {

        }

        public CreateUserDto user { get; set; } = default!;

        public class CreateUserDto : BaseDto
        {
            public string Email { get; set; } = default!;
            //public string Password { get; set; } = default!;
            public string? Picture { get; set; }
            public bool? IsAdmin { get; set; } = default!;

        }
    }
}
