using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation
{
    public class TokenRequestValidation : AbstractValidator<TokenRequest>
    {

        public TokenRequestValidation()
        {
            // validação necessária para a requisição do token

        }
    }
}
