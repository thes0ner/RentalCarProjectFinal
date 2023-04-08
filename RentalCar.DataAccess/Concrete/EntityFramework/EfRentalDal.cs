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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContextDb>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto()
                             {
                                 FullName = user.FirstName + " " + user.LastName,
                                 BrandName = brand.Name + " " + car.Model,
                                 ReturnDate = Convert.ToDateTime(rental.ReturnDate),
                                 RentalDate = rental.RentDate
                             };
                return result.ToList();


                //var result = from re in context.Rentals
                //             join br in context.Brands
                //             on re.Id equals br.Id
                //             join cu in context.Customers
                //             on re.Id equals cu.Id
                //             join ca in context.Cars
                //             on re.Id equals ca.Id
                //             select new RentalDetailDto
                //             {
                //                 FirstName = cu.FirstName,
                //                 LastName = cu.LastName,
                //                 BrandName = br.Name,
                //                 Model = ca.Model,
                //                 Year = ca.Year,
                //                 DailyPrice = ca.DailyPrice,
                //                 TotalDays = re.TotalDays,
                //                 RentDate = re.RentDate,
                //                 ReturnDate = re.ReturnDate,
                //                 TotalPrice = re.TotalPrice

                //             };
                //return result.ToList();
            }
        }
    }
}
