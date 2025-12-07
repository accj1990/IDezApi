using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IGetUserUseCase
    {
        Task<GetUserOutputModel> ExecuteAsync(GetUserInputModel input, CancellationToken cancellationToken);
    }
}
