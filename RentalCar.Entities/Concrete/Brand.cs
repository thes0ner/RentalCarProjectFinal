using RentalCar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.Concrete
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Founder { get; set; }
        public int FoundedYear{ get; set; }
        public string? Country { get; set; }

    }
}
