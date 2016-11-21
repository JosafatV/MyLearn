
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsCuentaDeUsuario
    {
        public static bool login(string username, string password)
        {
            using (MyLearnDBEntities entities = new MyLearnDBEntities())
            {
                return entities.USUARIO.Any(user => user.Id == username && user.Contrasena == password);
            }
        }
    }
}