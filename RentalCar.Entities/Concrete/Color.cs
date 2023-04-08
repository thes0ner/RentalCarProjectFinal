using RentalCar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? HexCode { get; set; }

    }
}
