using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Track
    {
        [JsonPropertyName("album")]
        public AlbumAllOf? AlbumAllOf { get; set; }

        [JsonPropertyName("artists")]
        public Artist[]? Artists { get; set; } = Array.Empty<Artist>();

        [JsonPropertyName("available_markets")]
        public string[]? AvailableMarkets { get; set; } = Array.Empty<string>();

        [JsonPropertyName("disc_number")]
        public int? DiscNumber { get; set; }

        [JsonPropertyName("duration_ms")]
        public int? DurationMs { get; set; }

        [JsonPropertyName("explicit")]
        public bool? Explicit { get; set; }

        [JsonPropertyName("external_ids")]
        public ExternalId[]? ExternalIds { get; set; } = Array.Empty<ExternalId>();

        [JsonPropertyName("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string? Id { get; set; } = string.Empty;

        [JsonPropertyName("is_playable")]
        public bool? IsPlayable { get; set; }

        [JsonPropertyName("linked_from")]
        public Track? LinkedFrom { get; set; }

        [JsonPropertyName("restrictions")]
        public Restriction[]? Restrictions { get; set; } = Array.Empty<Restriction>();

        [JsonPropertyName("name")]
        public string? Name { get; set; } = string.Empty;

        [JsonPropertyName("popularity")]
        public int? Popularity { get; set; }

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; set; } = string.Empty;

        [JsonPropertyName("track_number")]
        public int? TrackNumber { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; } = string.Empty;

        [JsonPropertyName("uri")]
        public string? Uri { get; set; } = string.Empty;

        [JsonPropertyName("is_local")]
        public bool? IsLocal { get; set; }
    }
}
