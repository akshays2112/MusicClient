using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class ExternalUrl
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; set; } = string.Empty;
    }
}
