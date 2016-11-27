
using System.Linq;
using MyEmployeeWebApi.Models;

namespace MyEmployeeWebApi.Controllers
{
    /// <summary>
    /// clase que autentica un usuario
    /// </summary>
    public class clsCuentaDeUsuario
    {
        /// <summary>
        /// verifica si el suuario y la controaseña son correctas
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool login(string username, string password)
        {
            using (MyLearnDBEntities entities = new MyLearnDBEntities())
            {
                //si existe alguna coincidencia
                return entities.USUARIO_MYEMPLOYEE.Any(user => user.NombreUsuario == username && user.Contrasena == password);
            }
        }

    }
}