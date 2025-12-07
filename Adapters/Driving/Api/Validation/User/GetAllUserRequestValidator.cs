using FluentValidation;

using IDezApi.Api.Dtos.Request;

namespace IDezApi.Api.Validation.User
{
    public class GetAllUserRequestValidator : AbstractValidator<GetAllUserRequest>
    {
        public GetAllUserRequestValidator()
        {
            RuleFor(x => x.Ids)
                 .Must(ids => ids.Length <= 100)
                 .WithMessage("You can request a maximum of 100 user IDs.");

            RuleFor(x => x.limit)
                .InclusiveBetween(1, 100)
                .WithMessage("Limit must be between 1 and 100.");

            RuleFor(x => x.offset)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Offset must be zero or greater.");
        }
    }
}
