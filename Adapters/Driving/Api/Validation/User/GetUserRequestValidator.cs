using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation.User
{
    public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("User ID is required.")
                .NotEmpty().WithMessage("User ID is required.");

        }
    }
}
