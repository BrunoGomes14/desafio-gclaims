using Newtonsoft.Json;

namespace api.Util
{
    public static class HttpRequest
    {
        public static T Get<T>(string sUrl)
        {
            string sResult = "";
            
            using (HttpClient client = new HttpClient())
            {
                sResult = client.GetAsync(sUrl)
                                .Result
                                .Content
                                .ReadAsStringAsync()
                                .Result;
            }

            return JsonConvert.DeserializeObject<T>(sResult)!;
        }
    }
}