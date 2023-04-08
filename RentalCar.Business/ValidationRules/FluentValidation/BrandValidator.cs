using FluentValidation;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().MaximumLength(50);
            RuleFor(b => b.Founder).NotEmpty().MaximumLength(50);
            RuleFor(b => b.FoundedYear).InclusiveBetween(1900, DateTime.Now.Year);
            RuleFor(b => b.Country).NotEmpty().MaximumLength(50);
        }
    }
}
