using Newtonsoft.Json;

namespace api.Util
{
    public class HttpRequest
    {
        public static T Get<T>(string sUrl)
        {
            string sResult = "";
            HttpClient client = new HttpClient();

            sResult = client.GetAsync(sUrl)
                            .Result
                            .Content
                            .ReadAsStringAsync()
                            .Result;

            return JsonConvert.DeserializeObject<T>(sResult)!;
        }
    }
}