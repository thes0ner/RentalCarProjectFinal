using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentalCar.Core.DataAccess.EntityFrameworkRepository;
using RentalCar.DataAccess.Abstract;
using RentalCar.Entities.Concrete;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                             join carImage in context.CarImages
                             on ca.Id equals carImage.CarId into Images
                             from image in Images.DefaultIfEmpty()
                             group new { ca, br, co, image } by ca.Id
                into carGroup
                             select new CarDetailDto
                             {
                                 BrandName = carGroup.First().br.Name,
                                 ColorName = carGroup.First().co.Name,
                                 Model = carGroup.First().ca.Model,
                                 Year = carGroup.First().ca.Year,
                                 DailyPrice = carGroup.First().ca.DailyPrice,
                                 FuelType = carGroup.First().ca.FuelType,
                                 Mileage = carGroup.First().ca.Mileage,
                                 ImagePath = carGroup.Select(c => c.image == null ? "DefaultImage.jpg" : c.image.ImagePath).ToList()

                             };
                return result.ToList();
            }
        }
    }
}
