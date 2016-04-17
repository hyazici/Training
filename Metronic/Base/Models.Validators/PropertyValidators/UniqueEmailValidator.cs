using FluentValidation.Validators;
using Ponera.Base.Contracts.BusinessLayer;

namespace Ponera.Base.Models.Validators.PropertyValidators
{
    public class UniqueEmailValidator : PropertyValidator
    {
        private readonly ISecurityBusiness _securityBusiness;

        public UniqueEmailValidator(ISecurityBusiness securityBusiness)
            : base ("Bu email adresi kullanımda")
        {
            _securityBusiness = securityBusiness;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var emailAdress = context.PropertyValue as string;

            return !_securityBusiness.IsUserExists(emailAdress);
        }
    }
}
