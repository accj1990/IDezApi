using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface ILoginUseCase
    {
        Task<LoginOutputModel> ExecuteAsync(LoginInputModel input, CancellationToken cancellationToken);
    }
}
