using Newtonsoft.Json;

namespace api.Domain.Entity
{
    public class CharacterComics
    {
        [JsonProperty("thumbnail")]
        public Thumbnail? Thumbnail { get; set;}
    }
}