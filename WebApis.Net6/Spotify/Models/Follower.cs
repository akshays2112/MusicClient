using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Follower
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
