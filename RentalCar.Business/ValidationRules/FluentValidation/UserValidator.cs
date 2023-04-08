using Castle.Core.Resource;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.Core.Entities.Concrete;
using RentalCar.DataAccess.Concrete.EntityFramework;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(50);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.PasswordHash).NotEmpty();
            
        }
    }
}
