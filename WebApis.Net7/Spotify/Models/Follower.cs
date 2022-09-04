using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Follower
{
    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}
