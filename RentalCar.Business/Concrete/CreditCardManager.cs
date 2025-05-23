using RentalCar.Business.Abstract;
using RentalCar.Business.BusinessAspects.Autofac;
using RentalCar.Business.Constants;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("user,Admin")]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        [SecuredOperation("user,Admin")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }

        [SecuredOperation("user,Admin")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardRemoved);
        }

        public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        {
           return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c=>c.CustomerId == customerId),Messages.CreditCardCustomersListed);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
           return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c=>c.Id == id));
        }

    }
}
