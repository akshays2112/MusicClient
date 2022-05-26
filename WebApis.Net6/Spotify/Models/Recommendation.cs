using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class Recommendation
{
    [JsonPropertyName("seeds")]
    public Seed[]? Seeds { get; set; }

    [JsonPropertyName("tracks")]
    public Track[]? Tracks { get; set; }
}
