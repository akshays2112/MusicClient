using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class UserProfile
{
    [JsonPropertyName("country")]
    public string? Country { get; set; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string? Email { get; set; } = string.Empty;

    [JsonPropertyName("explicit_content")]
    public ExplicitContent? ExplicitContent { get; set; }

    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("followers")]
    public Follower? Followers { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("images")]
    public Image[]? Images { get; set; } = Array.Empty<Image>();

    [JsonPropertyName("product")]
    public string? Product { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;
}
