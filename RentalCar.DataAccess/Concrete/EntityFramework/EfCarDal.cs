using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContextDb>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.Id
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 Model = ca.Model,
                                 Year = ca.Year,
                                 DailyPrice = ca.DailyPrice,
                                 FuelType = ca.FuelType,
                                 Mileage = ca.Mileage,
                                 Description = ca.Description,

                             };
                return result.ToList();
            }
        }
    }
}
