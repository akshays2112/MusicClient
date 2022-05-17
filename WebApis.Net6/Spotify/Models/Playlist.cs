using System.Text.Json.Serialization;
using static WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6.Spotify.Models
{
    public class Playlist
    {
        [JsonPropertyName("collaborative")]
        public bool Collaborative { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrl[] ExternalUrls { get; set; } = Array.Empty<ExternalUrl>();

        [JsonPropertyName("followers")]
        public Follower[] Followers { get; set; } = Array.Empty<Follower>();

        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = Array.Empty<Image>();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public OwnerAllOf? OwnerAllOf { get; set; }

        [JsonPropertyName("public")]
        public string Public { get; set; } = string.Empty;
    }
}
