using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RTracks
{
    [JsonPropertyName("tracks")]
    public Track[]? Tracks { get; set; }
}
