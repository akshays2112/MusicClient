using System.Text.Json.Serialization;
using static WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6.Spotify.Models
{
    public class Artist
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrl[] ExternalUrls { get; set; } = Array.Empty<ExternalUrl>();

        [JsonPropertyName("followers")]
        public Follower[] Followers { get; set; } = Array.Empty<Follower>();

        [JsonPropertyName("genres")]
        public string[] Genres { get; set; } = Array.Empty<string>();

        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = Array.Empty<Image>();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("type")]
        public ObjectType Type { get; set; } = ObjectType.artist;

        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;
    }
}
