using Core.Aspects.Autofac.Validation;
using RentalCar.Business.Abstract;
using RentalCar.Business.BusinessAspects.Autofac;
using RentalCar.Business.Constants;
using RentalCar.Business.ValidationRules.FluentValidation;
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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        //[ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

            var result = BusinessRules.Run(CheckIfColorNameExist(color.Name));
            if (result != null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.AddedColor);
        }


        public IResult Delete(Color color)
        {
            var result = BusinessRules.Run(CheckIfRecordDeleteExist(color.Id));
            if (result != null)
            {
                return result;
            }

            _colorDal.Delete(color);
            return new SuccessResult(Messages.DeletedColor);
        }

        //[ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run(CheckIfRecordUpdateExist(color.Id));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.UpdatedColor);
        }


        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ListedColors);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }


        public IDataResult<List<ColorDetailDto>> GetColorDetails()
        {
            return new SuccessDataResult<List<ColorDetailDto>>(_colorDal.GetColorDetails(), Messages.ListedColorDetails);
        }

        private IResult CheckIfColorNameExist(string name)
        {

            var result = _colorDal.GetAll(c => c.Name == name).Any();

            if (result)
            {
                return new ErrorResult(Messages.ColorNameAlreadyExist);
            }
            return new SuccessResult();
        }


        private IResult CheckIfRecordUpdateExist(int id)
        {
            var result = _colorDal.GetAll(c => c.Id == id).Any();

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
            var result = _colorDal.GetAll(c => c.Id == id).Any();

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
