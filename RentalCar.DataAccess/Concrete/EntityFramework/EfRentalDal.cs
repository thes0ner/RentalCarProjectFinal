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
                                 Id = rental.Id,
                                 CarId = rental.CarId,
                                 CustomerId = customer.Id,
                                 FullName = user.FirstName + " " + user.LastName,
                                 BrandName = brand.Name + " " + car.Model,
                                 ReturnDate = rental.ReturnDate,
                                 RentalDate = rental.RentDate
                             };
                return result.ToList();
            }
        }


        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime returnDate)
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {

                if (rentDate >= returnDate)
                {
                    return false;
                }

                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);

                bool isValidRentDate = context.Set<Rental>()
                                    .Any(r => r.CarId == carId && (
                                            (rentDate >= r.RentDate && rentDate < r.ReturnDate) ||
                                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                                            (r.RentDate >= rentDate && r.RentDate <= returnDate)||
                                            (rentDate == r.RentDate && returnDate == r.ReturnDate)
                                            )
                                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
