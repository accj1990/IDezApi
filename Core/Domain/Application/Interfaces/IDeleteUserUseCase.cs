using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IDeleteUserUseCase
    {
        Task<DeleteUserOutputModel> ExecuteAsync(DeleteUserInputModel input, CancellationToken cancellationToken);
    }
}
