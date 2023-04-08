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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedCar);
        }


        public IResult Delete(Car car)
        {
            var result = BusinessRules.Run(CheckIfRecordDeleteExist(car.Id));
            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }


        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckIfRecordUpdateExist(car.Id));
            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedCar);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedCars);
        }


        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedCarDetails);

        }

        //private IResult CheckIfCarModelExist(string modelName, int year)
        //{
        //    var result = _carDal.GetAll(c => c.Model == modelName && c.Year == year).Any();

        //    if (result)
        //    {
        //        return new ErrorResult(Messages.CarModelAlreadyExist);
        //    }
        //    return new SuccessResult();

        //}

        private IResult CheckIfRecordUpdateExist(int id)
        {
            var result = _carDal.GetAll(c => c.Id == id).Any();

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
            var result = _carDal.GetAll(c => c.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RecordDoesNotExist);
            }
            else
            {
                return new SuccessResult();
            }
        }



    }
}
