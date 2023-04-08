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
    [PerformanceAspect(20)]
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("Brand.all,Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {

            var result = BusinessRules.Run(CheckIfBrandNameExist(brand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.AddedBrand);
        }

        [SecuredOperation("Brand.all,Admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfRecordDeleteExist(brand.Id));

            if (result != null)
            {
                return result;
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeletedBrand);
        }

        [SecuredOperation("Brand.all,Admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfRecordUpdateExist(brand.Id));

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.UpdatedBrand);
        }

        [SecuredOperation("Brand.all,Admin")]
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ListedBrands);
        }

        [SecuredOperation("Brand.all,Admin")]
        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id));
        }

        /// <summary>
        /// Checks whether Brand Name exist 
        /// </summary>
        /// <param name="name">Brand Name</param>
        /// <returns></returns>
        private IResult CheckIfBrandNameExist(string name)
        {
            var result = _brandDal.GetAll(b => b.Name == name).Any();

            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExist);
            }
            return new SuccessResult();

        }


        /// <summary>
        /// Checks whether Record Update exist
        /// </summary>
        /// <param name="id">Brand Id</param>
        /// <returns></returns>
        private IResult CheckIfRecordUpdateExist(int id)
        {
            var result = _brandDal.GetAll(b => b.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RecordDoesNotExist);
            }
            else
            {
                return new SuccessResult();
            }

        }


        /// <summary>
        /// Check whether Record Delete exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private IResult CheckIfRecordDeleteExist(int id)
        {
            var result = _brandDal.GetAll(b => b.Id == id).Any();

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
