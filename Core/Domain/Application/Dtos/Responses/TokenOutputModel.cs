using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Common;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class TokenOutputModel : BaseOutputModel<AcessTokenDto>
    {
        public TokenOutputModel() : base()
        {
        }
    }
}
