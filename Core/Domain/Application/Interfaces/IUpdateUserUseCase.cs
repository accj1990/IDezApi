using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IUpdateUserUseCase
    {
        Task<UpdateUserOutputModel> ExecuteAsync(UpdateUserInputModel input, CancellationToken cancellationToken);
    }
}
