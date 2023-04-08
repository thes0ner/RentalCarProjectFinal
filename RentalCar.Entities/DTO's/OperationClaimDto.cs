using RentalCar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Entities.DTO_s
{
    public class OperationClaimDto : IDto
    {
        public int Id { get; set; }
        public string?Name { get; set; }
        public string?UserName { get; set; }
    }
}
