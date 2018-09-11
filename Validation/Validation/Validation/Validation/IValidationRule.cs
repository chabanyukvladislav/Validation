namespace Validation.Validation
{
    public interface IValidationRule<T>
    {
        bool Validate(T value);
    }
}
