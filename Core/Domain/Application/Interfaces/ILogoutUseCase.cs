using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface ILogoutUseCase
    {
        Task<LogoutOutputModel> ExecuteAsync(LogoutInputModel input, CancellationToken cancellationToken);
    }
}
