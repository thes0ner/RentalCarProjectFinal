using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.DTO_s
{
    public class RentalDetailDto
    {

        public string FullName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }


        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string? BrandName { get; set; }
        //public string? Model { get; set; }
        //public int Year { get; set; }
        //public decimal DailyPrice { get; set; }
        //public int TotalDays { get; set; }
        //public DateTime RentDate { get; set; }
        //public DateTime ReturnDate { get; set; }
        //public decimal TotalPrice { get; set; }

    }
}
