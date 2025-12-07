using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.CreateUserOutputModel;
using static IDezApi.Domain.Application.Dtos.Responses.GetAllUserOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class GetAllUserOutputModel : BaseOutputModel<GetAllUserDto>
    {

        public GetAllUserOutputModel() : base() { }

        public GetAllUserDto list { get; set; } = default!;

        public class GetAllUserDto
        {
            public List<CreateUserDto> items { get; set; } = default!;

        }
    }
}
