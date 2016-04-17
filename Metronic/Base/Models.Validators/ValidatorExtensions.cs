using FluentValidation;
using FluentValidation.Validators;
using Ponera.Base.Models.Validators.PropertyValidators;

namespace Ponera.Base.Models.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator((IPropertyValidator)new NotNullOrEmpty()).WithErrorCode("not_null_or_empty_error");
        }
    }
}
