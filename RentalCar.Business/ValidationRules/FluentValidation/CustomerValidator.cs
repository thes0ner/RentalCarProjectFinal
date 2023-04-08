using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.DataAccess.Concrete.EntityFramework;
using RentalCar.Entities.Concrete;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(c => c.UserId).GreaterThan(0).NotEmpty();
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Phone).NotEmpty().Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Phone number must be in the international format: +[country code][number].");
            RuleFor(c => c.Address).NotEmpty().MaximumLength(100);
            RuleFor(c => c.City).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Country).NotEmpty().MaximumLength(50);


        }
    }
}
