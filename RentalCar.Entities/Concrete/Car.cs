﻿using RentalCar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string? Model { get; set; }
        public string Plate { get; set; }
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public string? FuelType { get; set; }
        public int Mileage { get; set; }
        public string? Description { get; set; }

    }

}
