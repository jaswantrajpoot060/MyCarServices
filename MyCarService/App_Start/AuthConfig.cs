
using System.Collections.Generic;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;

namespace MyCarService
{
    public static class AuthConfig
    {
        //online Demo
        //public static void RegisterAuth()
        //{
        //    GoogleOAuth2Client clientGoog = new GoogleOAuth2Client("lghiuhgiuergikeuhdgikhedgkihedkih.apps.googleusercontent.com", "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");
        //    IDictionary<string, string> extraData = new Dictionary<string, string>();
        //    OpenAuth.AuthenticationClients.Add("google", () => clientGoog, extraData);
        //}

        //offline Demo
        public static void RegisterAuth()
        {
            GoogleOAuth2Client clientGoog = new GoogleOAuth2Client("hrgjiyeriuteityuieytuie.apps.googleusercontent.com", "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");
            IDictionary<string, string> extraData = new Dictionary<string, string>();
            OpenAuth.AuthenticationClients.Add("google", () => clientGoog, extraData);
        }
    }
}
