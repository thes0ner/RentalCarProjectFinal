using FluentValidation;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().GreaterThan(0);
            RuleFor(r => r.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(r => r.TotalDays).NotEmpty().GreaterThan(0);
            RuleFor(r => r.RentDate).NotEmpty().Must(BeAValidDate).LessThan(r => r.ReturnDate);
            RuleFor(r => r.ReturnDate).NotEmpty().Must(BeAValidDate).GreaterThan(r => r.RentDate);
            RuleFor(r => r.TotalPrice).NotEmpty().GreaterThan(0);
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default && date > DateTime.MinValue && date < DateTime.MaxValue;
        }
    }
}
