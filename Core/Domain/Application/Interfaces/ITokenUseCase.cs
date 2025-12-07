using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Domain.Application.Interfaces
{
    public interface ITokenUseCase
    {
        Task<TokenOutputModel> ExecuteAsync(TokenInputModel input, CancellationToken cancellationToken);
    }
}
