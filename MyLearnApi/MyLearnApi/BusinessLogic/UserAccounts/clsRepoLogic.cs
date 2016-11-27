
using MyLearnApi.Models;
using MyLearnApi.Models.DriveIntegration;
using System.Data.Entity.Infrastructure;

namespace MyLearnApi.BusinessLogic.UserAccounts
{
    public class clsRepoLogic
    {

        private static MyLearnDBEntities db = new MyLearnDBEntities();
        
        /// <summary>
        /// almancena las credenciales de google drive de un usuario
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        public static DriveCredentials createNewCredentials(DriveCredentials cred)
        {
            db.DriveCredentials.Add(cred);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //si ya existe
                if (db.DriveCredentials.Find(cred.UserId) != null )
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

        
            return cred;
        }

        /// <summary>
        /// uploads the file and returns the WebContentLink
        /// </summary>
        /// <returns></returns>
        public static  string uploadFile(byte[] byteArray,string IdUsuario, string fileName, string contentType)
        {
            
            DriveCredentials cred = db.DriveCredentials.Find(IdUsuario);
            //get tokens of the database
            if (cred != null)
            {
                //set tokens to the drive connection
                clsDriveConn.access_token = cred.AccessToken;
                clsDriveConn.refresh_token = cred.RefreshToken;

            }
            //sube el archivoy devuelve el content link
            return clsDriveConn.getContentLink(fileName, contentType, byteArray);
        }


    }
}