using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using File = Google.Apis.Drive.v2.Data.File;


namespace GoogleDriveAPI
{
    class GoogleDriveAPIClient
    {
        private static string[] Scopes = { DriveService.Scope.Drive };
        private static string ApplicationName = "MyLearn";

        private static string _fileName = "Drive_Test";
        private static string _filePath = @"C:\Users\Sebastian\Desktop\kuhk.txt";
        private static string _contentType = "Text/txt";

        static  void Main(string[] args)
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



            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = System.Environment.CurrentDirectory;//.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath =  Path.Combine(creadPath, "DriveApiCredentials", "DriveCredentials.json");

                return GoogleWebAuthorizationBroker.AuthorizeAsync( GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,  
                    "User",  
                    CancellationToken.None,  
                    new FileDataStore(creadPath, true))
                    
                    .Result;                    
            }
        }

        /**
         *  This class create the drive service with the credentials and the app name
         * @credentials: This argument receives the credentials for a connection
         * 
        **/
        private static DriveService GetDriveService(UserCredential credentials)
        {
            return new DriveService(
                new BaseClientService.Initializer {
                    HttpClientInitializer = credentials,
                    ApplicationName = ApplicationName
                });

        }


        /**
         *  This class is the one in charge of uploading the file to Drve 
         * @service: DriveService to make the request
         * return: The webContentLink from the uploaded file that will be neccesary for the dowload of the file later on,
         * this link will be stored into the database to retrived to the view later.
         * 
        **/
        public static string UploadFileToDrive(DriveService service, string fileName, string filePath,
            string contentType)
        {

            var fileMetadata = new File();
            fileMetadata.LastModifyingUserName = fileName;
            fileMetadata.Title = fileName;

            FilesResource.InsertMediaUpload request;


            //----------Esto se cambia por el archivo recibido por el WebService
            
            using (var stream = new FileStream(_filePath, FileMode.Open))
            {
                request = service.Files.Insert(fileMetadata, stream, "");
                request.Upload();
            }
           
            //-----------------------------------

            var file = request.ResponseBody;
            return file.WebContentLink;
        }
    }
}
