using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Metadata;
using RentalCar.Core.DataAccess.EntityFrameworkRepository;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, RentalCarContextDb>, ICreditCardDal
    {

    }
}
