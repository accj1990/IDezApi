using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Domain.Enums;

namespace IDezApi.Api.Validation
{
    public class BuscarMunicipiosValidation : AbstractValidator<BuscarMunicipiosRequest>
    {
        private readonly List<string> estados = new()
        {
            "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA",
            "MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN",
            "RS","RO","RR","SC","SP","SE","TO"
        };

        public BuscarMunicipiosValidation()
        {
            RuleFor(x => x.Uf)
                .NotNull().WithMessage(PatternsMessagesValidation.NotNullField)
                .NotEmpty().WithMessage(PatternsMessagesValidation.NotEmptyField)
                .Must(uf => estados.Contains(uf)).WithMessage(PatternsMessagesValidation.InvalidField);
        }
    }
}
