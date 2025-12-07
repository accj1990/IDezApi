using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Picture);

        }
    }
}
