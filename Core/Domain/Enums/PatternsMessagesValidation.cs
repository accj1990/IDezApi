namespace IDezApi.Domain.Enums
{
    public static class PatternsMessagesValidation
    {

        public const string RequestInValid = "Request cannot be null.";

        public const string InvalidField = "The field '{PropertyName}' is invalid.";

        public const string NotNullField = "The field '{PropertyName}' cannot be null.";

        public const string NotEmptyField = "The field '{PropertyName}' cannot be empty.";

        public const string RequiredField = "The field '{PropertyName}' is required.";

        public const string MaxLengthField = "The field '{PropertyName}' must be at most {MaxLength} characters long.";

        public const string MinLengthField = "The field '{PropertyName}' must be at least {MinLength} characters long.";

        public const string ExactLengthField = "The field '{PropertyName}' must be exactly {ExactLength} characters long.";

        public const string RangeField = "The field '{PropertyName}' must be between {From} and {To}.";



    }
}
