
namespace Common
{
    public class UrlIdentity
    {
        public const string Api_Gateway = "https://localhost:5010";
        public const string Identity_Server = "https://localhost:7001";
        public const string Notes_Api = "https://localhost:7031";
        public const string Notes_Client = "https://localhost:5002";

        public const string Sign_In = Notes_Client + "/signin-oidc";
        public const string Sign_Out = Notes_Client + "/signout-callback-oidc";

        public const string Notes = "/notes";
        public const string Notes_Id = "/notes/{0}";
    }
}
