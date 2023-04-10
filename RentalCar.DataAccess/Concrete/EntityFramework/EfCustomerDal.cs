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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalCarContextDb>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {

                var result = from cu in context.Customers
                             join us in context.Users
                             on cu.Id equals us.Id
                             select new CustomerDetailDto
                             {
                                 Id = cu.Id,
                                 UserId = cu.UserId,
                                 FirstName = cu.FirstName,
                                 LastName = cu.LastName,
                                 Email = cu.Email,
                                 Country = cu.Country,

                             };
                return result.ToList();

            }
        }
    }
}
