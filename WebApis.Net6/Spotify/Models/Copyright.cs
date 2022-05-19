using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class Copyright
{
    [JsonPropertyName("text")]
    public string? Text { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string? CopyrightType { get; set; } = string.Empty;
}
