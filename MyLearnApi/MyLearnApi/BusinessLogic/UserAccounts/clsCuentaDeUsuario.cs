
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsCuentaDeUsuario
    {


        public const byte ROL_ESTUDIANTE = 1;
        public const byte ROL_EMPRESA = 2;
        public const byte ROL_PROFESOR = 3;


       
        public static bool login(string username, string password)
        {
            using (MyLearnDBEntities entities = new MyLearnDBEntities())
            {
                return entities.USUARIO.Any(user => user.NombreDeUsuario == username && user.Contrasena == password);
            }
        }


        public static byte getRol(string username)
        {
            using (MyLearnDBEntities entities = new MyLearnDBEntities())
            {

                if (entities.VIEW_ESTUDIANTE.Any(u => u.NombreDeUsuario == username))
                    return ROL_ESTUDIANTE;
                else if (entities.VIEW_EMPRESA.Any(u => u.NombreDeUsuario == username))
                    return ROL_EMPRESA;
                else if (entities.VIEW_PROFESOR.Any(u => u.NombreDeUsuario == username))
                    return ROL_PROFESOR;
                else
                    return 0;
            }
        }

    

    }
}