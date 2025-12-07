using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface IGetAllUserUseCase
    {
        Task<GetAllUserOutputModel> ExecuteAsync(GetAllUserInputModel input, CancellationToken cancellationToken);
    }
}
