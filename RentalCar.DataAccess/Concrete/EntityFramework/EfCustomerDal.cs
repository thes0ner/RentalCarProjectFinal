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
                             select new CustomerDetailDto
                             {
                                 FirstName = cu.FirstName,
                                 LastName = cu.LastName,
                                 Email = cu.Email,
                                 Phone = cu.Phone,
                                 Address = cu.Address,
                                 City = cu.City,
                                 Country = cu.Country
                             };
                return result.ToList();
            }
        }
    }
}
