using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using File = Google.Apis.Drive.v2.Data.File;
using Google.Apis.Http;
using System.Text;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;

namespace MyLearnApi.Models.DriveIntegration
{
    public class clsDriveConn
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "MyLearn";
        public static string UserIdentifier { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public string getContentLink(string fileName, string contentType)
        {

            UserCredential credential = getUserCredential();
            DriveService service = GetDriveService(credential);
            //uploading file
            string response = UploadFileToDrive(service, fileName, contentType);

            return response;

        }


        /// <summary>
        /// This class get the information of the user credentials for DRIVE
        /// </summary>
        /// <returns></returns>
        private static UserCredential getUserCredential()
        {
            clsClientSecret secret = new clsClientSecret();

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                
                ClientSecrets = new ClientSecrets
                {
                    ClientId = secret.client_id,
                    ClientSecret = secret.client_secret
                },
                Scopes = new[] { DriveService.Scope.Drive }
            });

            var credential = new UserCredential(flow, UserIdentifier, new TokenResponse
            {
                AccessToken = "ya29.Ci-iA0Xe6xWpzzlIma2YzUvWRG-k1CsNxpaM-z6NBVfA2tIKsX8IRdBd8QZcuxmcAg",
                RefreshToken = "1/ZQZjfjO4nNxnf5M--aM0T1CwkzCxb4vpi6sOnnuWqrg"
            });
            return credential;
        }

        
        /**
         *  This class create the drive service with the credentials and the app name
         * @credentials: This argument receives the credentials for a connection
         * 
        **/
        
        private static DriveService GetDriveService(UserCredential credentials)
        {

            var service = new DriveService(new BaseClientService.Initializer
            {
                ApplicationName = ApplicationName, //ok
                HttpClientInitializer = credentials, //ok
                DefaultExponentialBackOffPolicy = ExponentialBackOffPolicy.Exception | ExponentialBackOffPolicy.UnsuccessfulResponse503
            });

            return service;

        }


        /**
         *  This class is the one in charge of uploading the file to Drve 
         * @service: DriveService to make the request
         * return: The webContentLink from the uploaded file that will be neccesary for the dowload of the file later on,
         * this link will be stored into the database to retrived to the view later.
         * 
        **/
        public static string UploadFileToDrive(DriveService service, string fileName, string contentType)
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
            Stream stream = new MemoryStream(byteArray);
            var fileMetadata = new File();
            fileMetadata.LastModifyingUserName = fileName;
            fileMetadata.Title = fileName;
            FilesResource.InsertMediaUpload request;
            request = service.Files.Insert(fileMetadata, stream, "");
            request.Upload();
            var file = request.ResponseBody;
            return file.WebContentLink;

        }

    }
}
