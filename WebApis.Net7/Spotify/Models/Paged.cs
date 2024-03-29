﻿using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Paged<T>
{
    [JsonPropertyName("href")]
    public string? Href { get; set; } = string.Empty;

    [JsonPropertyName("items")]
    public T[]? Items { get; set; } = Array.Empty<T>();

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}
