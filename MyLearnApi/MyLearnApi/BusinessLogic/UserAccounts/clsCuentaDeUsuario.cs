
using System.Linq;
using MyLearnApi.Models;


namespace MyLearnApi.BusinessLogic
{
    public class clsCuentaDeUsuario
    {


        public const byte ROL_ESTUDIANTE = 1;
        public const byte ROL_EMPRESA = 2;
        public const byte ROL_PROFESOR = 3;

        private static MyLearnDBEntities entities = new MyLearnDBEntities();


        public static bool login(string username, string password)
        {

            USUARIO lobj_usuario = entities.USUARIO.Where(u => u.NombreDeUsuario == username).First<USUARIO>();
            if (lobj_usuario != null)
            {
                return BCrypt.CheckPassword(password, lobj_usuario.Contrasena);
            }
            else
            {
                return false;
            }
                            
        }


        public static byte getRol(string username)
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