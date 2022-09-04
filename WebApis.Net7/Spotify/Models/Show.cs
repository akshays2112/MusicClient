using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Show
{
    [JsonPropertyName("available_markets")]
    public string[]? AvailableMarkets { get; set; } = Array.Empty<string>();

    [JsonPropertyName("copyrights")]
    public Copyright[]? Copyrights { get; set; } = Array.Empty<Copyright>();

    [JsonPropertyName("description")]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("html_description")]
    public string? HTMLDescription { get; set; } = string.Empty;

    [JsonPropertyName("explicit")]
    public bool? Explicit { get; set; }

    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("images")]
    public Image[]? Images { get; set; } = Array.Empty<Image>();

    [JsonPropertyName("is_externally_hosted")]
    public bool? IsExternallyHosted { get; set; }

    [JsonPropertyName("languages")]
    public string[]? Languages { get; set; } = Array.Empty<string>();

    [JsonPropertyName("media_type")]
    public string? MediaType { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;

    [JsonPropertyName("episodes")]
    public Paged<Episode>? Episodes { get; set; }
}
