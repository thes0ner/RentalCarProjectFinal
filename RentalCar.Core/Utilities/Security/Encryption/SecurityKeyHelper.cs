using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        /// <summary>
        /// SymmetricSecurityKey nesnesi, bir simetrik anahtarın depolanması ve işlenmesi için kullanılır 
        /// ve bu anahtarı işlemek için kullanılacak bir nesne oluşturur. Kendisi bir nesne döndürmez.
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
