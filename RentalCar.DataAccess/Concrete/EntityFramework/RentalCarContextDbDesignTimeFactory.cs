using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataAccess.Concrete.EntityFramework
{
    public class RentalCarContextDbDesignTimeFactory : IDesignTimeDbContextFactory<RentalCarContextDb>
    {
        public RentalCarContextDb CreateDbContext(string[] args)
        {
            var context = new RentalCarContextDb();
            return context;
        }
    }
}
