using Castle.Core.Resource;
using Core.Aspects.Autofac.Validation;
using RentalCar.Business.Abstract;
using RentalCar.Business.BusinessAspects.Autofac;
using RentalCar.Business.Constants;
using RentalCar.Business.ValidationRules.FluentValidation;
using RentalCar.Core.Aspects.Autofac.Caching;
using RentalCar.Core.Aspects.Autofac.Performance;
using RentalCar.Core.Business;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using RentalCar.DataAccess.Abstract;
using RentalCar.DataAccess.Concrete.EntityFramework;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Concrete
{
    [PerformanceAspect(5)]
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("user,Admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckAvailability(rental.CarId, rental.RentDate));
            if (result != null)
            {
                return result;

            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        
        }

        [SecuredOperation("user,Admin")]
        public IResult CheckCarStatus(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult(Messages.RentalDateOk);
            }
            return new ErrorResult(Messages.RentalReturnDateError);
        }



        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckAvailability(rental.CarId, rental.RentDate));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRental);
        }

        [SecuredOperation("user,Admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfRecordUpdateExist(rental.Id));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedRental);
        }


        [SecuredOperation("user,Admin")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ListedRentals);
        }

        [SecuredOperation("user,Admin")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        [SecuredOperation("user,Admin")]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.ListedRentalDetails);
        }

        private IResult CheckIfRecordUpdateExist(int id)
        {
            var result = _rentalDal.GetAll(c => c.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RecordDoesNotExist);
            }
            else
            {
                return new SuccessResult();
            }

        }

        private IResult CheckIfRecordDeleteExist(int id)
        {
            var result = _rentalDal.GetAll(c => c.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RecordDoesNotExist);
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfRentalExist(int id)
        {
            var result = _rentalDal.GetAll(r => r.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RentalAlreadyExist);
            }
            else
            {
                return new SuccessResult();
            }
        }



        //Bussines logic and validation for renting car!
        //Checks the availability of the car.
        private IResult CheckAvailability(int carId, DateTime newRentDate)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId);
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].ReturnDate > newRentDate)
                    {
                        return new ErrorResult(Messages.CarIsNotAvailable);
                    }

                }

            }
            return new SuccessResult();

        }

    }

}

