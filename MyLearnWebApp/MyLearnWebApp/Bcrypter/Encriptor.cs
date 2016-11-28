using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearnWebApp.Bcrypter
{
    class Encriptor
    {

        private string getHash ()
        {
            return BCrypt.GenerateSalt();
        }

        private string hashPassword(string myPassword, string mySalt)
        {
            string myHash = BCrypt.HashPassword(myPassword, mySalt);
            return myHash;
        }

        private bool checkPassword(string myPassword, string myHash)
        {
            bool PasswordMatch = BCrypt.CheckPassword(myPassword, myHash);
            return PasswordMatch;
        }

    }

}

