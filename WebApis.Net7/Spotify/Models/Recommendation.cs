using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Recommendation
{
    [JsonPropertyName("seeds")]
    public Seed[]? Seeds { get; set; }

    [JsonPropertyName("tracks")]
    public Track[]? Tracks { get; set; }
}
