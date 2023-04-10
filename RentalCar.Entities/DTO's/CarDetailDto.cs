using RentalCar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.DTO_s
{
    public class CarDetailDto : IDto
    {

        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public string? FuelType { get; set; }
        public decimal Mileage { get; set; }
        public List<string> ImagePath { get; set; }

    }
}
