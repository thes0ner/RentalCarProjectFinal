using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<CreditCard> GetById(int id);
        IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId);

    }
}
