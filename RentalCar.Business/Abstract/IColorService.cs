using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
        IDataResult<Color> GetById(int id);
        IDataResult<List<Color>> GetAll();
        IDataResult<List<ColorDetailDto>> GetColorDetails();
    }
}
