﻿using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Album
{
    [JsonPropertyName("album_type")]
    public string? AlbumType { get; set; } = string.Empty;

    [JsonPropertyName("total_tracks")]
    public int? TotalTracks { get; set; }

    [JsonPropertyName("available_markets")]
    public string[]? AvailableMarkets { get; set; } = Array.Empty<string>();

    [JsonPropertyName("external_urls")]
    public ExternalUrls? ExternalUrls { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("images")]
    public Image[]? Images { get; set; } = Array.Empty<Image>();

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("release_date_precision")]
    public string? ReleaseDatePrecision { get; set; } = string.Empty;

    [JsonPropertyName("restrictions")]
    public Restriction[]? Restrictions { get; set; } = Array.Empty<Restriction>();

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string? Uri { get; set; } = string.Empty;

    [JsonPropertyName("artists")]
    public Artist[]? Artists { get; set; } = Array.Empty<Artist>();

    [JsonPropertyName("tracks")]
    public Paged<Track>? Tracks { get; set; }
}
