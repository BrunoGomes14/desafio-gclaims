using Newtonsoft.Json;

namespace api.Domain.Entity
{
    public class MarvelResponse<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; } = "";

        [JsonProperty("data")]
        public Data<T> Data { get; set; } = new Data<T>();
    }

    public class Data<T>
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public T? Results { get; set; }
    }
}