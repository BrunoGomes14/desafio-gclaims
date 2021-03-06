using System.Text;
using api.Domain.Entity;
using api.Util;
using Microsoft.AspNetCore.WebUtilities;

namespace api.Requests
{
    public class MavelHttpRequest : IRequests
    {   
        private MarvelConfig Config { get; set; }

        public MavelHttpRequest(MarvelConfig config)
        {
            Config = config;
        }

        public List<CharacterResumed> GetCharacters(CharacterFilter filter)
        {           
            MarvelResponse<List<CharacterResumed>> response;
            Dictionary<string, string> dicParams = CreateQueryParams(filter);
            string sUrlRequest = "";

            // Adicionamos a url e a query criada para consulta
            sUrlRequest = QueryHelpers.AddQueryString(Config.Url, dicParams!);

            // Realiza a requisição  
            response = api.Util.HttpRequest.Get<MarvelResponse<List<CharacterResumed>>>(sUrlRequest);

            if (response.Status.ToLower() != "ok")
                throw new ArgumentException("Erro durante requisitar personagens");

            return response.Data.Results!;
        }

        public List<CharacterComics> GetComics(int id)
        {            
            MarvelResponse<List<CharacterComics>> response;
            Dictionary<string, string> dicParams = new Dictionary<string, string>();
            string sUrlRequest = "";

            AddSecurityParamsAPI(ref dicParams);
            dicParams.Add("limit", "5");

            // Adicionamos a url e a query criada para consulta
            sUrlRequest = QueryHelpers.AddQueryString($"{Config.Url}/{id}/comics", dicParams!);

            // Realiza a requisição  
            response = api.Util.HttpRequest.Get<MarvelResponse<List<CharacterComics>>>(sUrlRequest);

            if (response.Status.ToLower() != "ok")
                throw new ArgumentException("Erro durante requisitar personagens");

            return response.Data.Results!;
        }

        private Dictionary<string, string> CreateQueryParams(CharacterFilter filter)
        {
            Dictionary<string, string> dicParams = new Dictionary<string, string>();
            
            AddSecurityParamsAPI(ref dicParams);

            if (filter.NameStartsWith.Length > 0)
                dicParams.Add("nameStartsWith", filter.NameStartsWith);

            dicParams.Add("orderBy", filter.OrderBy);
            dicParams.Add("limit", filter.Limit.ToString());
            dicParams.Add("offset", filter.OffSet.ToString());

            return dicParams;
        }

        private void AddSecurityParamsAPI(ref Dictionary<string, string> dicParams)
        {
            long lTimeStamp = DateTime.UtcNow.Ticks;
            string sHash = string.Empty;
        
            sHash = CreateHashKey(lTimeStamp, Config.PublicKey, Config.PrivateKey);
        
            dicParams.Add("hash", sHash);
            dicParams.Add("apikey", Config.PublicKey);
            dicParams.Add("ts", lTimeStamp.ToString());
        }

        private string CreateHashKey(long lTimeStamp, string sPublicKey, string sPrivateKey)
        {
            StringBuilder sbBuilder = new StringBuilder();

            // Criamos uma string que será gerado o MD5 hash no formato requirido pela API
            sbBuilder.Append(lTimeStamp);
            sbBuilder.Append(sPrivateKey);
            sbBuilder.Append(sPublicKey);

            return MD5Generator.CreateHash(sbBuilder.ToString());
        }
    }
}