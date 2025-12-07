using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.DeleteUserOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class DeleteUserOutputModel : BaseOutputModel<DeleteUserDto>
    {
        public DeleteUserOutputModel() : base()
        {
        }
        public DeleteUserDto user { get; set; } = default!;

        public class DeleteUserDto : BaseEntity
        {
        }
    }
}
