using RentalCar.Core.Entities;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Core.Business
{
    public static class BusinessRules
    {

        public static IResult Run(params IResult[] logics)
        {

            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;

        }
    }
}
