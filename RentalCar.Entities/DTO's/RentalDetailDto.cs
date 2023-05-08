using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.DTO_s
{
    public class RentalDetailDto
    {

        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
