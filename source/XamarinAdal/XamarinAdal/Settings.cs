using System;
namespace XamarinAdal
{
    public class Settings
    {
        public static string AppServiceURL = "https://APP_SERVICE.azurewebsites.net/";
        public static string TenantId = "https://login.windows.net/common"; // the ID of the AD Tenant
        public static string ResourceId = "RESOURCE_ID"; // the ID of the Resource you are accessing
        public static string ClientId = "CLIENT_ID"; // the ID of the THIS client app (Native App registration)
        public static string ReturnUrl = $"{Settings.AppServiceURL}.auth/login/done"; // whatever returnURL's you have configured
    }
}