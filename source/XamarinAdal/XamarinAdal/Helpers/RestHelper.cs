using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace XamarinAdal.Helpers
{
    public class RestHelper
    {
        public static async Task<string> CallSecureRestAPI(string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION","2.0.0");

                var service = $"{Settings.AppServiceURL}api/values/";
                var httpResponse = await client.GetAsync(service);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                } 
            }
            return null;
        }
    }
}
