using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RTracks
{
    [JsonPropertyName("tracks")]
    public Track[]? Tracks { get; set; }
}
