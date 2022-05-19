using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class ExternalUrls
{
    [JsonPropertyName("spotify")]
    public string? Spotify { get; set; }
}
