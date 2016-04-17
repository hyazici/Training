using FluentValidation.Validators;

namespace Ponera.Base.Models.Validators.PropertyValidators
{
    public class NotNullOrEmpty : PropertyValidator, IPropertyValidator
    {
        public NotNullOrEmpty()
            : base("Value cannot be null or empty")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            string stringValue = context.PropertyValue?.ToString();

            return !string.IsNullOrEmpty(stringValue);
        }
    }
}
