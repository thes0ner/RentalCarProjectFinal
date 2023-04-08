﻿using Castle.Core.Resource;
using Core.Aspects.Autofac.Validation;
using RentalCar.Business.Abstract;
using RentalCar.Business.BusinessAspects.Autofac;
using RentalCar.Business.Constants;
using RentalCar.Business.ValidationRules.FluentValidation;
using RentalCar.Core.Aspects.Autofac.Caching;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("admin,add")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfRentalExist(rental.Id));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddedRental);
        }

        public IResult Delete(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfRecordDeleteExist(rental.Id));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRental);
        }

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


        [SecuredOperation("admin,list")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ListedRentals);
        }

        [SecuredOperation("admin,list")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,list")]
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
    }
}