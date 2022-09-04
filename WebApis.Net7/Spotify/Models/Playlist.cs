using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Playlist
{
    [JsonPropertyName("collaborative")]
    public bool? Collaborative { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

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

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("owner")]
    public OwnerAllOf? OwnerAllOf { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; set; } = string.Empty;

    [JsonPropertyName("tracks")]
    public Paged<Track>? Tracks { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;
}
