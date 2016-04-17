using FluentValidation;
using Ponera.Base.Contracts.BusinessLayer;
using Ponera.Base.Models.Validators.PropertyValidators;

namespace Ponera.Base.Models.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        private readonly ISecurityBusiness _securityBusiness;

        public UserModelValidator(ISecurityBusiness securityBusiness)
        {
            _securityBusiness = securityBusiness;

            RuleFor(model => model.FirstName).NotEmpty().WithMessage("Ad alanını girmeniz gerekiyor.");
            RuleFor(model => model.LastName).NotEmpty().WithMessage("Soyad alanını girmeniz gerekiyor.");
            RuleFor(model => model.Email).NotEmpty().WithMessage("Email alanını girmeniz gerekiyor.");
            RuleFor(model => model.Email).Length(3, 50).WithMessage("Email adresi 3 haneyle 50 hane arasında olmalı.");
            RuleFor(model => model.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz");
            RuleFor(model => model.Email).SetValidator(new UniqueEmailValidator(_securityBusiness));
            RuleFor(model => model.Password).NotEmpty().WithMessage("Şifre alanını girmeniz gerekiyor.");
        }
    }
}
