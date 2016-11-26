
using System.Collections.Generic;


namespace MyLearnApi.Models.DriveIntegration
{
    public class clsClientSecret
    {
        public  string client_id = "585034979069-c25comfmduvtpg25vj3nbnofr6h9i8rv.apps.googleusercontent.com";
        public  string project_id = "mylearnlaesposa";
        public  string auth_uri = "https://accounts.google.com/o/oauth2/auth";
        public  string token_uri = "https://accounts.google.com/o/oauth2/token";
        public  string auth_provider_x509_cert_url = "https://www.googleapis.com/oauth2/v1/certs";
        public  string client_secret = "zvD0IhvYcidpJN-YzC6HZdYf";
        public  List<string> redirect_uris =  new List<string>(new string[] { "https://oauth.io/auth", "http://localhost:55290/index.html" });
        public  List<string> javascript_origins = new List<string>(new string[] { "http://www.MyLearn.Com", "http://localhost:55290" });
    }
}