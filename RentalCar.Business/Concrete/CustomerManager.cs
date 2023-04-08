using Castle.Core.Resource;
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
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(
                CheckIfEmailExist(customer.Email),
                CheckIfPhoneExist(customer.Phone)
                );

            if (result != null)
            {
                return result;
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddedCustomer);
        }


        public IResult Delete(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfRecordDeleteExist(customer.Id));
            if (result != null)
            {
                return result;
            }

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeletedCustomer);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfRecordUpdateExist(customer.Id));
            if (result != null)
            {
                return result;
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpdatedCustomer);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ListedCustomers);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin")]

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.ListedCustomerDetails);
        }

        private IResult CheckIfRecordUpdateExist(int id)
        {
            var result = _customerDal.GetAll(c => c.Id == id).Any();

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
            var result = _customerDal.GetAll(c => c.Id == id).Any();

            if (!result)
            {
                return new ErrorResult(Messages.RecordDoesNotExist);
            }
            else
            {
                return new SuccessResult();
            }
        }


        private IResult CheckIfPhoneExist(string phone)
        {
            var result = _customerDal.GetAll(c => c.Phone == phone).Any();
            if (result)
            {
                return new ErrorResult(Messages.PhoneAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailExist(string email)
        {
            var result = _customerDal.GetAll(c => c.Email == email).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
