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
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedCar);
        }


        //[SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedCar);
        }


        //[SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }

        [SecuredOperation("user,Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedCars);
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<Car>> GetAllByDailyPrice(short min, short max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList());
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList());
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().ToList());
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailByBrandId(brandId));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailByCarId(carId));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetailByColorAndBrandId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailByColorAndBrandId(brandId, colorId));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailByColorId(colorId));
        }

        [SecuredOperation("user,Admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().ToList());
        }


    }
}
