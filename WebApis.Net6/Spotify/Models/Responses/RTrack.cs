using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RTrack
{
    [JsonPropertyName("added_at")]
    public DateTime? AddedAt { get; set; }

    [JsonPropertyName("track")]
    public Track? Track { get; set; }
}
