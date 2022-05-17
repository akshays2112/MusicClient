using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Context
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; } = string.Empty;

        [JsonPropertyName("href")]
        public string? Href { get; set; } = string.Empty;

        [JsonPropertyName("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; } = string.Empty;
    }
}
