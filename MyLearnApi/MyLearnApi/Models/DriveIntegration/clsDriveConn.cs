
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
      
        private static string ApplicationName = "MyLearn";
        public static string UserIdentifier { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public string getContentLink(string fileName, string contentType, byte[] byteArray)
        {

            UserCredential credential = getUserCredential();
            DriveService service = GetDriveService(credential);
            //uploading file
            string response = UploadFileToDrive(service, fileName, contentType, byteArray);

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
                Scopes = new[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile }
            });

            var credential = new UserCredential(flow, UserIdentifier, new TokenResponse
            {
                AccessToken = "ya29.Ci-iAz7NCKn0D0p7LF7GpBTKDSbQXWp9x9ve-Ba4_XNOhz1syOr2ddMwoA_tfMx_zA",
                RefreshToken = "1/ZK9-tBnulXJ2c7esvhQl2dRGIT7dqBzpzciyAk6E9mst0oisBn2Lz4l3AG2p6uvE"
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
        public static string UploadFileToDrive(DriveService service, string fileName, string contentType, byte[] byteArray)
        {

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
