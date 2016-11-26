using System.Linq;
using MyLearnApi.Models;
using MyLearnApi.Models.DriveIntegration;
using System.Text;


namespace MyLearnApi.BusinessLogic.UserAccounts
{
    public class clsRepoLogic
    {

        private MyLearnDBEntities db = new MyLearnDBEntities();
        private clsDriveConn driveConn = new clsDriveConn();
        /// <summary>
        /// almancena las credenciales de google drive de un usuario
        /// </summary>
        /// <param name="cred"></param>
        /// <returns></returns>
        public DriveCredentials createNewCredentials(DriveCredentials cred)
        {
            db.DriveCredentials.Add(cred);
            return cred;
        }

        /// <summary>
        /// uploads the file and returns the WebContentLink
        /// </summary>
        /// <returns></returns>
        public string uploadFile()
        {
            string jason = "{"
                               + "\"installed\": {"
                               + "\"client_id\": \"945542049910-ie4l7np3hup7qpev39stcc4o7rlti85j.apps.googleusercontent.com\","
                               + "\"project_id\": \"basic-computing-149501\","
                               + "\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth  \",  "
                               + "\"token_uri\": \"https://accounts.google.com/o/oauth2/token \", "
                               + "\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs  \","
                               + "\"client_secret\": \"EIuppefDWrd3rOh4RyYSt-DH\","
                               + "\"redirect_uris\": [ \"urn:ietf:wg:oauth:2.0:oob\", \"http://localhost \" ]"
                               + "}"
                        + "}";

            byte[] byteArray = Encoding.UTF8.GetBytes(jason);

            return driveConn.getContentLink("biber", "JSON/Json", byteArray);



        }


    }
}