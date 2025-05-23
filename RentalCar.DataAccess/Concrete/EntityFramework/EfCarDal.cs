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

        public List<CarDetailDto> GetCarDetail()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Model = car.Model,
                                 Plate = car.Plate,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 Year = car.Year,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == car.Id select ci.ImagePath).FirstOrDefault()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where b.Id == brandId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Model = car.Model,
                                 Plate = car.Plate,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 Year = car.Year,
                                 ImagePath = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where car.Id == carId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Model = car.Model,
                                 Plate = car.Plate,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 Year = car.Year,
                                 ImagePath = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId)
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where c.Id == colorId && b.Id == brandId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Model = car.Model,
                                 Plate = car.Plate,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 Year = car.Year,
                                 ImagePath = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where c.Id == colorId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Model = car.Model,
                                 Plate = car.Plate,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 Year = car.Year,
                                 ImagePath = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }

    //    public List<CarDetailDto> GetCarDetailByCar(int carId)
    //    {
    //        using (RentalCarContextDb context = new RentalCarContextDb())
    //        {
    //            var result = from ca in context.Cars
    //                         where ca.Id == carId
    //                         join br in context.Brands on ca.BrandId equals br.Id
    //                         join co in context.Colors on ca.ColorId equals co.Id
    //                         join carImage in context.CarImages on ca.Id equals carImage.CarId into Images
    //                         from image in Images.DefaultIfEmpty()
    //                         group new { ca, br, co, image } by ca.Id
    //                    into carGroup
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = carGroup.First().br.Name,
    //                             ColorName = carGroup.First().co.Name,
    //                             Model = carGroup.First().ca.Model,
    //                             Year = carGroup.First().ca.Year,
    //                             DailyPrice = carGroup.First().ca.DailyPrice,
    //                             Mileage = carGroup.First().ca.Mileage,
    //                             FuelType = carGroup.First().ca.FuelType,
    //                             Description = carGroup.First().ca.Description,
    //                             ImagePath = carGroup.Select(c => c.image == null ? "DefaultImage.jpg" : c.image.ImagePath).ToList()

    //                         };
    //            return result.ToList();

    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailByColor(int colorId)
    //    {
    //        using (RentalCarContextDb context = new RentalCarContextDb())
    //        {
    //            var result = from ca in context.Cars
    //                         where ca.ColorId == colorId
    //                         join br in context.Brands on ca.BrandId equals br.Id
    //                         join co in context.Colors on ca.ColorId equals co.Id
    //                         join carImage in context.CarImages on ca.Id equals carImage.CarId into Images
    //                         from image in Images.DefaultIfEmpty()
    //                         group new { ca, br, co, image } by ca.Id
    //            into carGroup
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = carGroup.First().br.Name,
    //                             ColorName = carGroup.First().co.Name,
    //                             Model = carGroup.First().ca.Model,
    //                             Year = carGroup.First().ca.Year,
    //                             DailyPrice = carGroup.First().ca.DailyPrice,
    //                             Mileage = carGroup.First().ca.Mileage,
    //                             FuelType = carGroup.First().ca.FuelType,
    //                             Description = carGroup.First().ca.Description,
    //                             ImagePath = carGroup.Select(c => c.image == null ? "DefaultImage.jpg" : c.image.ImagePath).ToList()

    //                         };
    //            return result.ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetails()
    //    {
    //        using (RentalCarContextDb context = new RentalCarContextDb())
    //        {
    //            var result = from ca in context.Cars
    //                         join br in context.Brands
    //                         on ca.BrandId equals br.Id
    //                         join co in context.Colors
    //                         on ca.ColorId equals co.Id
    //                         join carImage in context.CarImages
    //                         on ca.Id equals carImage.CarId into Images
    //                         from image in Images.DefaultIfEmpty()
    //                         group new { ca, br, co, image } by ca.Id
    //            into carGroup
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = carGroup.First().br.Name,
    //                             ColorName = carGroup.First().co.Name,
    //                             Model = carGroup.First().ca.Model,
    //                             Year = carGroup.First().ca.Year,
    //                             DailyPrice = carGroup.First().ca.DailyPrice,
    //                             Mileage = carGroup.First().ca.Mileage,
    //                             FuelType = carGroup.First().ca.FuelType,
    //                             Description = carGroup.First().ca.Description,
    //                             ImagePath = carGroup.Select(c => c.image == null ? "DefaultImage.jpg" : c.image.ImagePath).ToList()

    //                         };
    //            return result.ToList();
    //        }
    //    }

    //    public List<CarDetailDto> GetCarDetailsByBrand(int brandId)
    //    {
    //        using (RentalCarContextDb context = new RentalCarContextDb())
    //        {
    //            var result = from ca in context.Cars
    //                         where ca.BrandId == brandId
    //                         join br in context.Brands on ca.BrandId equals br.Id
    //                         join co in context.Colors on ca.ColorId equals co.Id
    //                         join carImage in context.CarImages on ca.Id equals carImage.CarId into Images
    //                         from image in Images.DefaultIfEmpty()
    //                         group new { ca, br, co, image } by ca.Id
    //            into carGroup
    //                         select new CarDetailDto
    //                         {
    //                             BrandName = carGroup.First().br.Name,
    //                             ColorName = carGroup.First().co.Name,
    //                             Model = carGroup.First().ca.Model,
    //                             Year = carGroup.First().ca.Year,
    //                             DailyPrice = carGroup.First().ca.DailyPrice,
    //                             Mileage = carGroup.First().ca.Mileage,
    //                             FuelType = carGroup.First().ca.FuelType,
    //                             Description = carGroup.First().ca.Description,
    //                             ImagePath = carGroup.Select(c => c.image == null ? "DefaultImage.jpg" : c.image.ImagePath).ToList()

    //                         };
    //            return result.ToList();
    //        }
    //    }
    //}
}

