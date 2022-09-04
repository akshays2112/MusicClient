using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Artist
{
    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("followers")]
    public Follower? Followers { get; set; }

    [JsonPropertyName("genres")]
    public string[]? Genres { get; set; } = Array.Empty<string>();

    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("images")]
    public Image[]? Images { get; set; } = Array.Empty<Image>();

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("popularity")]
    public int? Popularity { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;
}
