using FluentValidation;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.Model).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Year).InclusiveBetween(2000, DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c => c.FuelType).NotEmpty();
            RuleFor(c => c.Mileage).GreaterThan(0);

        }
    }
}
