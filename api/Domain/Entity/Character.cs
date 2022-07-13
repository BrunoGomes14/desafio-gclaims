using Newtonsoft.Json;

namespace api.Domain.Entity
{
    public class Character
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

        [JsonProperty("resourceURI")]
        public string? ResourceURI { get; set; }

        [JsonProperty("comics")]
        public Comics? Comics { get; set; }

        [JsonProperty("series")]
        public Series? Series { get; set; }

        [JsonProperty("stories")]
        public Stories? Stories { get; set; }

        [JsonProperty("events")]
        public Events? Events { get; set; }

        [JsonProperty("urls")]
        public List<Url>? Urls { get; set; }

        public bool Favorite { get; set; }
    }

    public class Comics
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string? CollectionURI { get; set; }

        [JsonProperty("items")]
        public List<Item>? Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Events
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string? CollectionURI { get; set; }

        [JsonProperty("items")]
        public List<Item>? Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Item
    {
        [JsonProperty("resourceURI")]
        public string? ResourceURI { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class Series
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string? CollectionURI { get; set; }

        [JsonProperty("items")]
        public List<Item>? Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Stories
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string? CollectionURI { get; set; }

        [JsonProperty("items")]
        public List<Item>? Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("extension")]
        public string? Extension { get; set; }
    }

    public class Url
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("url")]
        public string? UrlAcess { get; set; }
    }
}