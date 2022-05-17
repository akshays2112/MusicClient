using System.Text.Json.Serialization;
using static WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6.Spotify.Models
{
    public class UserProfile
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("explicit_content")]
        public ExplicitContent? ExplicitContent { get; set; }

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

        [JsonPropertyName("product")]
        public string Product { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public ObjectType Type { get; set; } = ObjectType.user;

        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;
    }
}
