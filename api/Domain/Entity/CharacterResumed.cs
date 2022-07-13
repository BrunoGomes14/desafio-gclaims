using Newtonsoft.Json;

namespace api.Domain.Entity
{
    public class CharacterResumed
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; } 

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail? Thumbnail { get; set; }
        public bool Favorite { get; set; } 
    }
}