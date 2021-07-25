using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ServicesExtensions
{
    public class AuthOptions
    {

        
        public const string ISSUER = "MyAuthServerKeyMaker"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена


        const string KEY = "TopSecretKey2021";   // ключ для шифрации

        public const int LIFETIME = 20; // время жизни токена - 20 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {

            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
