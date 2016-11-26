using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using File = Google.Apis.Drive.v2.Data.File;
using Newtonsoft.Json.Linq;
using Google.Apis.Http;
using System.Text;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;

namespace MyLearnApi.Controllers
{
    public class RepositoriosController : ApiController
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "MyLearn";

        private static string _fileName = "oh oh baby baby";
        private static string _filePath = @"C:\Users\Sebastian\Desktop\kuhk.txt";
        private static string _contentType = "JSON/json";

        public static string UserIdentifier { get; private set; }

        [HttpGet]
        public void Main()
        {


            //--------------------------Test Para upload File Drive

            Console.WriteLine("Create CREEDS");
            UserCredential credential = getUserCredential();

            Console.WriteLine("Get service");
            DriveService service = GetDriveService(credential);

            Console.WriteLine("Uploading File");
            var response = UploadFileToDrive(service, _fileName, _filePath, _contentType);
            Console.WriteLine(response);

        }

        /**
         *  This class get the information of the user credentials for DRIVE
         * 
         * 
        **/
        private static UserCredential getUserCredential()
        {

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "945542049910-ie4l7np3hup7qpev39stcc4o7rlti85j.apps.googleusercontent.com",
                    ClientSecret = "EIuppefDWrd3rOh4RyYSt-DH"
                },
                Scopes = new[] { DriveService.Scope.Drive }
            });

            var credential = new UserCredential(flow, UserIdentifier, new TokenResponse
            {
                AccessToken = "ya29.CjCiA2igTRXT7GMTm-iDYTWKA85jeXH9LAljB3QqN0tUjVzsg6OazQIrDpf5xtFUhWs",
                RefreshToken = "1/8JPtltWzwmTzEAc9r2eKVeVOCXglqCG-suuzrA65D5-8iwKCcDulbd4yXzq1EKxl"
            });
            return credential;

           

            /*string creadPath = @"C:\Users\Sebastian\Documents\";
                creadPath = Path.Combine(creadPath, "DriveApiCredentials", "DriveCredentials.json");

            FileDataStore credentialsFile = new FileDataStore(creadPath, true);


            return GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                   Scopes,
                   "User",
                   CancellationToken.None,
                   new FileDataStore(creadPath, true))

                   .Result;*/

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

           /* return new DriveService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credentials ,
                    ApplicationName = ApplicationName
                });*/

        }


        /**
         *  This class is the one in charge of uploading the file to Drve 
         * @service: DriveService to make the request
         * return: The webContentLink from the uploaded file that will be neccesary for the dowload of the file later on,
         * this link will be stored into the database to retrived to the view later.
         * 
        **/
        public static string UploadFileToDrive(DriveService service, string fileName, string filePath, string contentType)
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


            //----------Esto se cambia por el archivo recibido por el WebService

        //  using (var stream = new FileStream(_filePath, FileMode.Open))
          //  {
                request = service.Files.Insert(fileMetadata, stream, "");
                request.Upload();
            //}

            //-----------------------------------

            var file = request.ResponseBody;
            return file.WebContentLink;
        }

    }
}
