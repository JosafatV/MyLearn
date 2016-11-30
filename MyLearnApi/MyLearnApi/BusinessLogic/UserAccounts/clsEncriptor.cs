using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearnApi.BusinessLogic.UserAccounts
{
    public class clsEncriptor
    {
        //Genera una sal única para la contraseña
        private string getHash()
        {
            return BCrypt.GenerateSalt();
        }

        // Pone la sal y la contraseña juntas y crea el hash-contraseña que vamos a guardar en la base de datos
        private string hashPassword(string myPassword, string mySalt)
        {
            string myHash = BCrypt.HashPassword(myPassword, mySalt);
            return myHash;
        }

        //
        private bool checkPassword(string myPassword, string myHash)
        {
            bool PasswordMatch = BCrypt.CheckPassword(myPassword, myHash);
            return PasswordMatch;
        }
    }
}