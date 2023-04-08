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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentalCarContextDb>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (RentalCarContextDb context = new RentalCarContextDb())
            {
                var result = from br in context.Brands
                             select new BrandDetailDto
                             {
                                 Name = br.Name,
                                 Founder = br.Founder,
                                 FoundedYear = br.FoundedYear,
                                 Country = br.Country,
                             };
                return result.ToList();

            }
        }
    }
}
