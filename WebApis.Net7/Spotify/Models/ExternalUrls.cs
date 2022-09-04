using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class ExternalUrls
{
    [JsonPropertyName("spotify")]
    public string? Spotify { get; set; }
}
