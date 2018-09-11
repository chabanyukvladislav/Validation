using Validation.Validation;

namespace Validation
{
    class MainViewModel
    {
        public ValidatableObject<string> Date { get; }
        public ValidatableObject<string> Number { get; }
        public ValidatableObject<string> Str { get; }

        public MainViewModel()
        {
            Date = new ValidatableObject<string>(new DateValidator());
            Number = new ValidatableObject<string>(new NumberValidator());
            Str = new ValidatableObject<string>(new StrValidator());
        }
    }
}
