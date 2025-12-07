using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Domain.Enums;

namespace IDezApi.Api.Validation
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {

        public LoginRequestValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(PatternsMessagesValidation.RequiredField);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(PatternsMessagesValidation.RequiredField)
                .MinimumLength(6).WithMessage(PatternsMessagesValidation.MinLengthField);
        }
    }
}
