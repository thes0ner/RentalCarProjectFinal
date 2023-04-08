using RentalCar.Core.DataAccess.EntityFrameworkRepository;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentalCarContextDb>, IColorDal
    {
        public List<ColorDetailDto> GetColorDetails()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from co in context.Colors
                             select new ColorDetailDto
                             {
                                 Name = co.Name,
                                 HexCode = co.HexCode,
                             };
                return result.ToList();
            }
        }
    }
}
