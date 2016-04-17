using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;

namespace Ponera.Base.Models.Validators.PropertyValidators
{
    public class UniqueEmailValidatorRemote : FluentValidationPropertyValidator
    {
        public UniqueEmailValidatorRemote(ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules())
            {
                yield break;
            }

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage(Validator.ErrorMessageSource.GetString());

            var rule = new ModelClientValidationRule
            {
                ValidationType = "remote",
                ErrorMessage = message
            };

            rule.ValidationParameters.Add("url", "/validation/uniqueemail");

            yield return rule;
        }
    }
}
