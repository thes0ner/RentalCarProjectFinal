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
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int CustomerId { get; set; }
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal Mileage { get; set; }
        public string? FuelType { get; set; }
        public string? Description { get; set; }
        public List<string>? ImagePath { get; set; }

    }
}
