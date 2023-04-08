using RentalCar.Core.Entities.Concrete;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Abstract
{
    public interface IUserService
    {

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetById(int userId);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByEmail(string mail);


    }
}
