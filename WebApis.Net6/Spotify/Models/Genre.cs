using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Genre
    {
        [JsonPropertyName("genres")]
        public string[]? Genres { get; set; } = Array.Empty<string>();
    }
}
