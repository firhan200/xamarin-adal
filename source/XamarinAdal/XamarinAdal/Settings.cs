using System;
namespace XamarinAdal
{
    public class Settings
    {
        public static string AppServiceURL = "https://APP_SERVICE.azurewebsites.net/";
        public static string TenantId = "https://login.windows.net/common";
        public static string ResourceId = "RESOURCE_ID";
        public static string ClientId = "CLIENT_ID";
        public static string ReturnUrl = $"{Settings.AppServiceURL}.auth/login/done";
    }
}
