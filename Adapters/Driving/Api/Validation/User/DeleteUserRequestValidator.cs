using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation.User
{
    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("User ID is required.");
        }
    }
}
