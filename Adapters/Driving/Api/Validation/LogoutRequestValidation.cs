using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Domain.Enums;

namespace IDezApi.Api.Validation
{
    public class LogoutRequestValidation : AbstractValidator<LogoutRequest>
    {
        public LogoutRequestValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(PatternsMessagesValidation.RequiredField);

            RuleFor(x => x.IdToken).NotEmpty().WithMessage(PatternsMessagesValidation.RequiredField);

        }
    }
}
