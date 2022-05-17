using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Category
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; } = string.Empty;

        [JsonPropertyName("icons")]
        public Image[]? Icons { get; set; } = Array.Empty<Image>();

        [JsonPropertyName("id")]
        public string? Id { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string? Name { get; set; } = string.Empty;
    }
}
