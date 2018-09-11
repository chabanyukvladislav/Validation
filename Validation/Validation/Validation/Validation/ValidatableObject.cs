using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Validation.Validation
{
    public class ValidatableObject<T>: INotifyPropertyChanged
    {
        private T value;

        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();
        public T Value {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public ValidatableObject(params IValidationRule<T>[] validations)
        {
            foreach (var val in validations)
                Validations.Add(val);
        }

        public bool IsValid => Validations.TrueForAll(v => v.Validate(Value));

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsValid)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
