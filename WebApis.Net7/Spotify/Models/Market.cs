using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Market
{
    [JsonPropertyName("markets")]
    public string[]? Markets { get; set; } = Array.Empty<string>();
}
