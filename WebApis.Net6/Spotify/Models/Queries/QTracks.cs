using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Queries;

public class QTracks
{
    [JsonPropertyName("tracks")]
    public QUri[]? Tracks { get; set; }
}
