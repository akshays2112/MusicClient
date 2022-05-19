using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class Image
{
    [JsonPropertyName("url")]
    public string? Url { get; set; } = string.Empty;

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }
}
