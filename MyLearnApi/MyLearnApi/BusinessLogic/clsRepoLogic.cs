
using MyLearnApi.Models;
using MyLearnApi.Models.DriveIntegration;
using System.Data.Entity.Infrastructure;
using System.IO;
using MyLearnApi.Models.TwitterIntegration;

namespace MyLearnApi.BusinessLogic.UserAccounts
{
    public class clsRepoLogic
    {

        private static MyLearnDBEntities db = new MyLearnDBEntities();
        private static clsTwitterConn pobj_twittConn = new clsTwitterConn();
        
        /// <summary>
        /// almancena las credenciales de google drive de un usuario
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        public static DriveCredentials createNewDriveCredentials(DriveCredentials cred)
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

        public static TWITTER_CREDENTIALS createNewTwitterCredentials(TWITTER_CREDENTIALS cred)
        {
            db.TWITTER_CREDENTIALS.Add(cred);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //si ya existe
                if (db.TWITTER_CREDENTIALS.Find(cred.UserId) != null)
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


        public string twittBadge(string idUsuario,string nombreEstudiante, string nombreBadge, string nombreCurso)
        {
            TWITTER_CREDENTIALS cred = db.TWITTER_CREDENTIALS.Find(idUsuario);
            //get tokens of the database
            if (cred != null)
            {
                //defaut application tokens
                pobj_twittConn.setConsumerKey("jUV15h3RmCiiTlewmoSICNdx2");
                pobj_twittConn.setConsumerSecret("EDugd5Ph71tuvmZmEfKXeaUQw5DDLJh1bjUSkhYuDd4p4p4TJn");
                //set user tokens
                pobj_twittConn.setUserAccessToken(cred.AccessToken);
                pobj_twittConn.setUserAccessSecret(cred.AccessTokenSecret);
                //sends twitt and return the twitt
                string twitt = nombreEstudiante +" ganó "+nombreBadge+" en "+nombreCurso;
                return pobj_twittConn.twitt(twitt);
            }
            //error no credentials
            else
                return "No twitter credentials for user : " + idUsuario ;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreTrabajo"></param>
        /// <returns></returns>
        public string twittSubasta(string nombreTrabajo)     
        {
          
            //defaut application tokens
            pobj_twittConn.setConsumerKey("BsJg0w7pVCPWUMO6LJ4KGlAGu");
            pobj_twittConn.setConsumerSecret("JD2DPyEq3gnroWOa1Iu4UtpxgzImEZ1lMi6Y0SiDgk9fHpC5ml");
            //set tokens of XMP twitter account
            pobj_twittConn.setUserAccessToken("804453874409107456-jp4oC99qlNsEAKzDpP6KVb5mJqMkMkV");
            pobj_twittConn.setUserAccessSecret("V8s9IYvvfdI1HX2moYsIu27V62VVbNtm0h79RqCZuicK4");
            //sends twitt and return the twitt
            string twitt = "Hay un nuevo proyecto: " + nombreTrabajo;
            return pobj_twittConn.twitt(twitt);
           

        }

    

        /// <summary>
        /// uploads the file and returns the WebContentLink
        /// </summary>
        /// <returns></returns>
        public static  string uploadFile(Stream byteArray,string IdUsuario, string fileName, string contentType)
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