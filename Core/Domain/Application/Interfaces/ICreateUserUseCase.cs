using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface ICreateUserUseCase
    {
        Task<CreateUserOutputModel> ExecuteAsync(CreateUserInputModel input, CancellationToken cancellationToken);

    }
}
