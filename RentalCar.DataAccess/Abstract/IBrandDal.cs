using RentalCar.Core.DataAccess;
using RentalCar.Core.Entities;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        List<BrandDetailDto> GetBrandDetails();
    }
}
