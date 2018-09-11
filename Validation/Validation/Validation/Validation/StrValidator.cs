namespace Validation.Validation
{
    public class StrValidator : IValidationRule<string>
    {
        public bool Validate(string value)
        {
            return value?.Length >= 5 && value?.Length <= 10;
        }
    }
}
