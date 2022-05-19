using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class Episode
{
    [JsonPropertyName("audio_preview_url")]
    public string? AudioPreviewUrl { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; } = string.Empty;

    [JsonPropertyName("html_description")]
    public string? HtmlDescription { get; set; } = string.Empty;

    [JsonPropertyName("duration_ms")]
    public int? DurationMs { get; set; }

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

    [JsonPropertyName("is_playable")]
    public bool? IsPlayable { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; } = string.Empty;

    [JsonPropertyName("languages")]
    public string[]? Languages { get; set; } = Array.Empty<string>();

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("release_date_precision")]
    public string? ReleaseDatePrecision { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;

    [JsonPropertyName("restrictions")]
    public Restriction[]? Restrictions { get; set; } = Array.Empty<Restriction>();

    [JsonPropertyName("show")]
    public Show? Show { get; set; }
}
