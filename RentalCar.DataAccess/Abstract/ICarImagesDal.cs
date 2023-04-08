using RentalCar.Core.DataAccess;
using RentalCar.DataAccess.Concrete.EntityFramework;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataAccess.Abstract
{
    public interface ICarImageDal :IEntityRepository<CarImage>
    {
    }
}
