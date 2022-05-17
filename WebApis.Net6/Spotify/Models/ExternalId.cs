using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class ExternalId
    {
        [JsonPropertyName("isrc")]
        public string? Isrc { get; set; } = string.Empty;

        [JsonPropertyName("ean")]
        public string? Ean { get; set; } = string.Empty;

        [JsonPropertyName("upc")]
        public string? Upc { get; set; } = string.Empty;
    }
}
