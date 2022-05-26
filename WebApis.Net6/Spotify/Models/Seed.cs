using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class Seed
{
    [JsonPropertyName("afterFilteringSize")]
    public int? AfterFilteringSize { get; set; }

    [JsonPropertyName("afterRelinkingSize")]
    public int? AfterRelinkingSize { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("initialPoolSize")]
    public int? InitialPoolSize { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;
}
