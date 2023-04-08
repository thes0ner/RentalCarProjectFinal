using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Core.Entities.Concrete
{
    /// <summary>
    /// Kullanicinin hangi operasyonlara erisebilecegini tanimlar.
    /// </summary>
    public class OperationClaim
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }


    }
}
