
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using File = Google.Apis.Drive.v2.Data.File;
using Google.Apis.Http;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v2.Data;
using System;
using System.Threading;

namespace MyLearnApi.Models.DriveIntegration
{
    /// <summary>
    /// Clase de conección con el repositorio de archivos Drive, provee métodos para subir archivos
    /// y obtener el link de descarga
    /// </summary>
    public class clsDriveConn
    {
      
        private static string ApplicationName = "MyLearn";
        public static string UserIdentifier { get; private set; }
        public static string access_token = "";
        public static string refresh_token = "";

        /*public static void set_acess_token(string token)
        {
            this.access_token = token;
        }

        public static void setRefresh_token(string token)
        {
            this.refresh_token = token;
        }*/
        /// <summary>
        /// 
        /// </summary>
        public static string getContentLink(string fileName, string contentType, Stream byteArray )
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
            //el objeto que contiene el client_secret.json
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

            //refresa el access token cada vez que necesite acceso
            access_token = flow.RefreshTokenAsync(secret.client_id, refresh_token , CancellationToken.None).Result.RefreshToken;
            
            //crea el credential con access token y refresh token de cada usuario
            var credential = new UserCredential(flow, UserIdentifier, new TokenResponse
            {
                AccessToken = access_token ,
                RefreshToken = refresh_token
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
        /// <summary>
        /// Inserta los permisos para hacer público el link de descarga del archivo
        /// </summary>
        /// <param name="service"> Servicio de drive </param>
        /// <param name="fileId"> Id del archivo al que se le da permiso </param>
        /// <param name="value"> email opcional </param>
        /// <param name="type"> el tipo de permiso  </param>
        /// <param name="role"> el rol del permiso </param>
        /// <returns></returns>
        public static  Permission InsertPermission(DriveService service, String fileId, String value,
                                                                                     String type, String role)
        {
            Permission newPermission = new Permission();
            newPermission.Value = value;
            newPermission.Type = type;
            newPermission.Role = role;
            try
            {
                return service.Permissions.Insert(newPermission, fileId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return null;
        }

        /**
         *  This class is the one in charge of uploading the file to Drve 
         * @service: DriveService to make the request
         * return: The webContentLink from the uploaded file that will be neccesary for the dowload of the file later on,
         * this link will be stored into the database to retrived to the view later.
         * 
        **/
        public static string UploadFileToDrive(DriveService service, string fileName, string contentType, Stream byteArray)
        {
           

            //convierte los bytes en un stream
           // Stream stream = new MemoryStream(byteArray);
            //construye la metadata
            var fileMetadata = new File();
            fileMetadata.LastModifyingUserName = fileName;
            fileMetadata.Title = fileName;
            FilesResource.InsertMediaUpload request;
            
          
            request = service.Files.Insert(fileMetadata, byteArray,contentType);
            request.Upload();
            var file = request.ResponseBody;
            
            //retorna el link de descarga del archivo
            if (file != null)
            {
                //le da permisos de lectura a cualquier usuario
                InsertPermission(service, file.Id, "", "anyone", "reader");
                return file.WebContentLink;
            }
               
            else
                return "Not found";
        }




    }
}
